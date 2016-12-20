using CDK.DataAccess.Models.cdk;
using CDK.DataAccess.Models.ddf;
using CDK.DataAccess.Repositories;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.ETL.Geographpy.Extenstions;

namespace CDK.ETL.Geography
{
    public class GeographyManager
    {
        public DbGeography ConvertLatLonToDbGeography(string longitude, string latitude)
        {
            var point = string.Format("POINT({1} {0})", latitude.Replace(',', '.'), longitude).Replace(',', '.');
            return DbGeography.FromText(point);
        }

        public bool IsPointInsidePolygon(DbGeometry polygon, double longitude, double latitude) //or DbGeography in your case
        {
            DbGeometry point = DbGeometry.FromText(string.Format("POINT({0} {1})", longitude, latitude), 4326);
            return polygon.Intersects(point);
        }

        public void BindBuildingToNeighborhood()
        {

            try
            {

                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    

                    var buildingAddress = uow.Repository<BuildingAddress>().Query(x => x.Lat != null || x.Lon != null).Select().ToList();

                    buildingAddress.ForEach(x => {

                        DbGeography point = this.ConvertLatLonToDbGeography(x.Lon, x.Lat);

                        var neighborHoodArea = uow.Repository<NeighborhoodArea>()
                        .Query(y => y.CoordinatesGeo.Intersects(point))
                        .Select()
                        .ToList();

                        if (neighborHoodArea != null && neighborHoodArea.Count() > 0)
                        {

                            neighborHoodArea.SortNeighborhoodAreaByPriority();

                            x.NeighborhoodAreaId = neighborHoodArea.FirstOrDefault().Id;
                            uow.Repository<BuildingAddress>().Update(x);

                            uow.SaveChanges();

                        }
                    });

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("!!!"); 
            }
        }
    }
}
