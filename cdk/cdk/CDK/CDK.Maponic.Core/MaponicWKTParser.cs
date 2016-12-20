using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;
using CDK.DataAccess.Repositories;
using CDK.DataAccess.Models.cdk;
using CdkMaponicWTKParser;
using Repository.Pattern.Ef6;
using CDK.ETL.Core.Managers;
using System.Data.Entity.SqlServer;

namespace CDK.Maponic.Core
{
    class MaponicWKTParser
    {

        private static int _SRID = 4326;

        static void Main(string[] args)
        {
            try
            {

                //InsertMetroAreaFromWKT();
                //InsertNeighborhoodFromWKT();
                //BuildUriAndSeo();
                //GenerateGeoJsonForNeighborhood();
                //GenerateGeoJsonForMetroArea();
                //BuildUriAndSeo();
                UpdateLevel();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static private void GenerateGeoJsonForNeighborhood()
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                List<long> nhasCount = uow.Repository<NeighborhoodArea>().Query().Select(x => x.Id).ToList();

                List<NeighborhoodArea> nhas = uow.Repository<NeighborhoodArea>().Query().Select().ToList();

                List<Tuple<WkbShape, Dictionary<string, object>>> shapes = null;
                Tuple<WkbShape, Dictionary<string, object>> tuple = null;

                foreach (var nh in nhas)
                {

                    WkbShape shape = WkbDecoder.Parse(nh.CoordinatesGeo.AsBinary());
                    Dictionary<string, object> properties = GetNhFeaturesProperties(nh.Id, nh.NeighborhoodAreaExtId, nh.ParentId, nh.LType, nh.NType, nh.HasChild, nh.ShortName);
                    tuple = new Tuple<WkbShape, Dictionary<string, object>>(shape, properties);

                    shapes = new List<Tuple<WkbShape, Dictionary<string, object>>>();
                    shapes.Add(tuple);

                    nh.CoordinatesAsText = WkbGeoJsonParser.ParseWkbToGeoJson(shapes);
                    nh.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;

                    uow.SaveChanges();
                    Console.WriteLine(">>> Inserted {0}", nh.Name);

                }
                
            }
        }

        static private void GenerateGeoJsonForMetroArea()
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                List<MetroArea> metros = uow.Repository<MetroArea>().Query().Include(x => x.NeighborhoodAreas).Select().ToList();

                foreach (var metro in metros)
                {

                    //Metro
                    List<Tuple<WkbShape, Dictionary<string, object>>> shapes = new List<Tuple<WkbShape, Dictionary<string, object>>>();
                    Dictionary<string, object> properties = GetMetroFeaturesProperties(metro.Id, metro.MetroAreaExtId, metro.ShortName);
                    WkbShape shape = WkbDecoder.Parse(metro.CoordinatesGeo.AsBinary());
                    Tuple<WkbShape, Dictionary<string, object>> tuple = new Tuple<WkbShape, Dictionary<string, object>>(shape, properties);
                    shapes.Add(tuple);
                    metro.MetroCoordinatesAsText = WkbGeoJsonParser.ParseWkbToGeoJson(shapes);

                    //Neighborhood
                    shapes = new List<Tuple<WkbShape, Dictionary<string, object>>>();
                    foreach (var nh in metro.NeighborhoodAreas)
                    {

                        // DbGeography geo = uow.Repository<NeighborhoodArea>().Query(x => x.Id == nh.Id).Select(y => SqlSpatialFunctions.Reduce(y.CoordinatesGeo, 10)).FirstOrDefault();

                        shape = WkbDecoder.Parse(nh.CoordinatesGeo.AsBinary());
                        properties = GetNhFeaturesProperties(nh.Id, nh.NeighborhoodAreaExtId, nh.ParentId, nh.LType, nh.NType, nh.HasChild, nh.ShortName);
                        tuple = new Tuple<WkbShape, Dictionary<string, object>>(shape, properties);

                        shapes.Add(tuple);

                    }

                    metro.CoordinatesAsText = WkbGeoJsonParser.ParseWkbToGeoJson(shapes);
                    metro.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;

                    uow.SaveChanges();

                    Console.WriteLine(">>> Inserted {0}", metro.Name);
                    
                }
            }
        }

        static private void InsertMetroAreaFromWKT()
        {

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("maponics_custom_metros_objects.wkt"))
            {

                string line;

                //Skip header
                line = sr.ReadLine();
                try
                {
                    using (var context = new CDKDbContext())
                    using (var uow = new UnitOfWork(context))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {

                            //Get the states dictionnary
                            Dictionary<string, string> states = GetStateDictionnary();

                            //Bar separated file
                            String[] splitedLine = line.Split('|');

                            long extId = long.Parse(splitedLine[0]);
                            MetroArea metroArea = uow.Repository<MetroArea>().Query(x => x.MetroAreaExtId == extId).Select().FirstOrDefault();

                            if (metroArea == null)
                            {
                                metroArea = new MetroArea();
                                metroArea.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                            }
                            else
                            {
                                metroArea.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                            }

                            metroArea.MetroAreaExtId = extId;
                            metroArea.ShortName = splitedLine[1];
                            metroArea.MType = splitedLine[2];
                            metroArea.Country = "Canada";

                            //Separate metroAreraName from its states
                            string stateShortName = splitedLine[5].Split(',')[1].Trim();
                            string stateName = states.ContainsKey(stateShortName) ? states[stateShortName] : stateShortName;
                            metroArea.State = stateName;

                            metroArea.Name = splitedLine[5];
                            metroArea.CenterPointLat = splitedLine[6];
                            metroArea.CenterPointLon = splitedLine[7];
                            metroArea.MetroAreaExtVersion = splitedLine[9];

                            //Create center point of metro Area
                            metroArea.CenterPointGeo = DbGeography.FromText(string.Format("POINT({0} {1})", metroArea.CenterPointLon, metroArea.CenterPointLat), _SRID);
                            metroArea.CoordinatesGeo = DbGeography.MultiPolygonFromText(ReverseMultiPolygonString(splitedLine[10]), _SRID);

                            metroArea.Description = string.Format("Condos for sale or rent in {0}, {1}", metroArea.ShortName, metroArea.State);
                            metroArea.MetroAreaUri = string.Format("{0}/{1}", metroArea.State, metroArea.ShortName).ToUri();

                            //SEO
                            metroArea.SeoSlug = string.Format("{0}-{1}", metroArea.State, metroArea.ShortName).ToSlug();
                            metroArea.SeoDescription = string.Format("Condos for sale or rent in {0}, {1}", metroArea.ShortName, metroArea.State);
                            metroArea.SeoMetaDescription = string.Format("Condos for sale or rent in {0}, {1}", metroArea.ShortName, metroArea.State);
                            metroArea.SeoCaption = string.Format("Condos for sale or rent in {0}, {1}", metroArea.ShortName, metroArea.State);
                            metroArea.SeoTitle = string.Format("{0}, {1}", metroArea.ShortName, metroArea.State);
                            metroArea.SeoKeywords = string.Format("{0}, {1}, {2}", metroArea.ShortName, metroArea.State, metroArea.Country);
                            metroArea.SeoURI = string.Format("{0}/{1}", metroArea.State, metroArea.ShortName).ToUri();

                            //global fields
                            metroArea.Created = DateTime.Now;
                            metroArea.LastUpdate = DateTime.Now;
                            metroArea.CreatedBy = "ETL";
                            metroArea.LastUpdateBy = "ETL";

                            if (metroArea.ObjectState == Repository.Pattern.Infrastructure.ObjectState.Added)
                            {
                                uow.Repository<MetroArea>().Insert(metroArea);
                            }
                            else
                            {
                                uow.Repository<MetroArea>().Update(metroArea);
                            }
                        }

                        uow.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>> Error: ", e);
                }
            }
        }

        static private void InsertNeighborhoodFromWKT()
        {

            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("maponics_custom_neighborhoods_na_boundaries.wkt"))
            {

                string line;

                //Skip header
                line = sr.ReadLine();

                GeographyManager gm = new GeographyManager();

                try
                {

                    using (var context = new CDKDbContext())
                    using (var uow = new UnitOfWork(context))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {

                            NeighborhoodArea neighborhoodArea = null;

                            try
                            {

                                String[] splitedLine = line.Split('|');

                                long extId = long.Parse(splitedLine[0]);
                                neighborhoodArea = uow.Repository<NeighborhoodArea>().Query(x => x.NeighborhoodAreaExtId == extId).Select().FirstOrDefault();

                                if (neighborhoodArea==null)
                                {
                                    neighborhoodArea = new NeighborhoodArea();
                                    neighborhoodArea.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                                } 
                                else
                                {
                                    neighborhoodArea.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                                }

                                neighborhoodArea.CenterPointGeo = DbGeography.FromText("POINT(" + splitedLine[6] + " " + splitedLine[5] + ")", 4326);
                                MetroArea ma = gm.GetAssociatedMetroArea(neighborhoodArea.CenterPointGeo);

                                if (ma == null)
                                {
                                    ma = gm.GetAssociatedMetroAreaByDistance(neighborhoodArea.CenterPointGeo);
                                }

                                if (ma != null)
                                {

                                    neighborhoodArea.NeighborhoodAreaExtId = extId;
                                    neighborhoodArea.ShortName = splitedLine[1];
                                    neighborhoodArea.Name = splitedLine[1];
                                    neighborhoodArea.NType = splitedLine[2];

                                    neighborhoodArea.CenterPointLat = splitedLine[5];
                                    neighborhoodArea.CenterPointLon = splitedLine[6];

                                    if (splitedLine[8] != "")
                                        neighborhoodArea.ParentId = long.Parse(splitedLine[8]);

                                    neighborhoodArea.MetroAreaId = ma.Id;

                                    try
                                    {
                                        neighborhoodArea.CoordinatesGeo = DbGeography.MultiPolygonFromText(ReverseMultiPolygonString(splitedLine[10]), 4326);
                                    }
                                    catch (Exception)
                                    {
                                        neighborhoodArea.CoordinatesGeo = DbGeography.MultiPolygonFromText(splitedLine[10], 4326);
                                    }
                                    
                                    neighborhoodArea.SeoDescription = "Condo for sale or rent in " + neighborhoodArea.ShortName;
                                    neighborhoodArea.SeoCaption = neighborhoodArea.Name;

                                    //metroArea.CoordinatesAsText = RemoveType(splitedLine[10]);

                                    //global fields
                                    neighborhoodArea.Created = DateTime.Now;
                                    neighborhoodArea.LastUpdate = DateTime.Now;
                                    neighborhoodArea.CreatedBy = "ETL";
                                    neighborhoodArea.LastUpdateBy = "ETL";

                                    if (neighborhoodArea.ObjectState == Repository.Pattern.Infrastructure.ObjectState.Added)
                                    {
                                        uow.Repository<NeighborhoodArea>().Insert(neighborhoodArea);
                                    }
                                    else
                                    {
                                        uow.Repository<NeighborhoodArea>().Update(neighborhoodArea);
                                    }

                                    uow.SaveChanges();

                                }
                                else
                                {
                                    Console.WriteLine(">>> No metro area associated");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(">>> Error: ", e);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>> Error: ", e);
                }
            }
        }

        private static string UpdateLevel()
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                try
                {

                    List<NeighborhoodArea> nhas = uow.Repository<NeighborhoodArea>().Query().Include(x => x.MetroArea).Select().ToList();

                    foreach (var currentNh in nhas)
                    {

                        int level = 1;
                        List<string> nhLevelsValues = new List<string>();

                        //Second level
                        var nhParent = (from currentNhParent in nhas
                                        where currentNh.ParentId == currentNhParent.NeighborhoodAreaExtId
                                        select currentNhParent).FirstOrDefault();

                        if (nhParent != null)
                        {

                            level++;

                            //Third level
                            nhParent = (from currentNhParent in nhas
                                        where nhParent.ParentId == currentNhParent.NeighborhoodAreaExtId
                                        select currentNhParent).FirstOrDefault();

                            if (nhParent != null)
                            {

                                level++;

                                //Third level
                                nhParent = (from currentNhParent in nhas
                                            where nhParent.ParentId == currentNhParent.NeighborhoodAreaExtId
                                            select currentNhParent).FirstOrDefault();

                                //Fourth level
                                if (nhParent != null)
                                {
                                    level++;
                                }

                            }
                        }                                 

                        currentNh.HasChild = nhas.Any(x => x.ParentId == currentNh.NeighborhoodAreaExtId);
                             
                        currentNh.LType = level;
                        currentNh.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;

                    }

                    uow.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;

        }

        private static string BuildUriAndSeo()
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                try
                {

                    List<NeighborhoodArea> nhas = uow.Repository<NeighborhoodArea>().Query().Include(x => x.MetroArea).Select().ToList();

                    foreach (var currentNh in nhas)
                    {

                        List<string> nhLevelsValues = new List<string>();

                        //First level 
                        nhLevelsValues.Add(currentNh.ShortName);

                        //Second level
                        var nhParent = (from currentNhParent in nhas
                                        where currentNh.ParentId == currentNhParent.NeighborhoodAreaExtId
                                        select currentNhParent).FirstOrDefault();

                        if (nhParent != null)
                        {

                            nhLevelsValues.Add(nhParent.ShortName);

                            //Third level
                            nhParent = (from currentNhParent in nhas
                                        where nhParent.ParentId == currentNhParent.NeighborhoodAreaExtId
                                        select currentNhParent).FirstOrDefault();

                            if (nhParent != null)
                            {
                                nhLevelsValues.Add(nhParent.ShortName);
                            }
                        }

                        //Reverse the list to start by macro and finish by sub
                        nhLevelsValues.Reverse();
                        nhLevelsValues.ForEach(x => 
                        {
                            x.ToUri();
                        });

                        if (currentNh.MetroArea != null)
                        {

                            currentNh.NeighborhoodAreaUri = string.Format("{0}/{1}/", currentNh.MetroArea.State, currentNh.MetroArea.ShortName).ToUri() + string.Join("/", nhLevelsValues.ToArray()).ToUri();

                            //SEO
                            currentNh.SeoTitle = string.Format("{0}, {1}, {2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.SeoSlug = string.Format("{0}-{1}-{2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State).ToSlug();
                            currentNh.SeoKeywords = string.Format("{0}, {1}, {2}", string.Join(" ", nhLevelsValues.ToArray()), currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.SeoDescription = string.Format("Condos for sale or rent in {0}, {1}, {2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.Description = string.Format("Condos for sale or rent in {0}, {1}, {2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.SeoMetaDescription = string.Format("Condos for sale or rent in {0}, {1}, {2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.SeoCaption = string.Format("Condos for sale or rent in {0}, {1}, {2}", currentNh.ShortName, currentNh.MetroArea.ShortName, currentNh.MetroArea.State);
                            currentNh.SeoURI = string.Format("{0}/{1}/", currentNh.MetroArea.State, currentNh.MetroArea.ShortName).ToUri() + string.Join("/", nhLevelsValues.ToArray()).ToUri();


                        }

                        currentNh.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;

                    }

                    uow.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;

        }

        static private string ReverseMultiPolygonString(string multiPolygonsString)
        {

            string firstLevelRegex = @"(\(\(\((.*?)\)\)\))";
            string secondLevelRegex = @"(\(\((.*?)\)\))";
            string thirdLevelRegex = @"(\((.*?)\))";

            List<List<string>> nestedList = new List<List<string>>();

            Regex regex = new Regex(firstLevelRegex);
            Match matchNestedOne = regex.Match(multiPolygonsString);

            string str = null;
            if (matchNestedOne.Success)
            {
                str = matchNestedOne.Value.Remove(matchNestedOne.Value.LastIndexOf(')'));
                str = str.Remove(0, 1);
            }

            regex = new Regex(secondLevelRegex);
            var matches = regex.Matches(str);

            foreach (Match matchNestedTwo in matches)
            {

                str = matchNestedTwo.Value.Remove(matchNestedTwo.Value.LastIndexOf(')'));
                str = str.Remove(0, 1);

                regex = new Regex(thirdLevelRegex);
                matches = regex.Matches(str);

                List<string> polygons = new List<string>();
                foreach (Match matchNestedThree in matches)
                {

                    str = matchNestedThree.Value.Remove(matchNestedThree.Value.LastIndexOf(')'));
                    str = str.Remove(0, 1);

                    polygons.Add(str);

                }

                nestedList.Add(polygons);

            }

            return BuildMultiPolygonString(nestedList);

        }

        static private string BuildMultiPolygonString(List<List<string>> nestedList)
        {

            StringBuilder sb = new StringBuilder();
            foreach (List<string> polygons in nestedList)
            {

                sb.Append("(");

                foreach (string polygon in polygons)
                {

                    List<string> toReverse = GetCoordinatesListString(polygon);

                    toReverse.Reverse();

                    string reversedCoordinates = WriteCoordinatesListString(toReverse);

                    sb.Append("(").Append(reversedCoordinates).Append("),");

                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("),");

            }

            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Insert(0, "MULTIPOLYGON(").Append(")");

            return sb.ToString();

        }

        static private string WriteCoordinatesListString(List<string> coordinateList)
        {

            StringBuilder sb = new StringBuilder();
            foreach (string coordinatesString in coordinateList)
            {
                sb.Append(coordinatesString).Append(",");
            }

            string returnedCoordinate = sb.ToString();

            if (returnedCoordinate.LastIndexOf(',') != -1)
            {
                returnedCoordinate = returnedCoordinate.Remove(returnedCoordinate.LastIndexOf(','));
            }

            return returnedCoordinate;

        }

        static private List<string> GetCoordinatesListString(string coordinateGroup)
        {
            List<string> coordinatesList = new List<string>();
            if (coordinateGroup.IndexOf(',') != -1)
            {
                List<string> inputList = new List<string>(coordinateGroup.Split(','));
                foreach (string coordinatesString in inputList)
                {
                    coordinatesList.Add(coordinatesString.Trim());
                }
            }
            else
            {
                coordinatesList.Add(coordinateGroup);
            }

            return coordinatesList;
        }

        static private Dictionary<string, object> GetMetroFeaturesProperties(long id, long? extId, string name)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();

            properties.Add("stroke-opacity", 1);
            properties.Add("stroke-width", 2);
            properties.Add("stroke", "#ACACAC");
            properties.Add("fill-opacity", 0);
            properties.Add("data-id", id);
            properties.Add("data-ext-id", extId);
            properties.Add("name", name);

            return properties;

        }

        static private Dictionary<string, object> GetNhFeaturesProperties(long id, long? extId, long? parentId, long lType, string nType, bool hasChild, string name)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();

            properties.Add("stroke-opacity", 1);
            properties.Add("stroke-width", 2);
            properties.Add("stroke", "#ACACAC");
            properties.Add("fill-opacity", 0);
            properties.Add("data-id", id);
            properties.Add("data-ext-id", extId);
            properties.Add("name", name);

            if (parentId != null)
            {
                properties.Add("parent-id", parentId);
            }
            else
            {
                properties.Add("parent-id", 0);
            }

            properties.Add("ltype", lType);
            properties.Add("ntype", nType);
            properties.Add("has-child", hasChild);

            if (lType == 1)
            {
                properties.Add("z-index", 12);
            }
            else if (lType == 2)
            {
                properties.Add("z-index", 13);
            }
            else if (lType == 3)
            {
                properties.Add("z-index", 14);
            }

            return properties;

        }

        static private Dictionary<string, string> GetStateDictionnary()
        {

            Dictionary<string, string> stateList = new Dictionary<string, string>();

            stateList.Add("AB", "Alberta");
            stateList.Add("BC", "British Columbia");
            stateList.Add("MB", "Manitoba");
            stateList.Add("NB", "New Brunswick");
            stateList.Add("NL", "Newfoundland and Labrador");
            stateList.Add("NT", "Northwest Territories");
            stateList.Add("NS", "Nova Scotia");
            stateList.Add("NU", "Nunavut");
            stateList.Add("ON", "Ontario");
            stateList.Add("PE", "Prince Edward Island");
            stateList.Add("QC", "Quebec");
            stateList.Add("SK", "Saskatchewan");
            stateList.Add("YT", "Yukon");

            return stateList;

        }
    }
}

