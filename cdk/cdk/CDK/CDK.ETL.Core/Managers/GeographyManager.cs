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

namespace CDK.ETL.Core.Managers
{
    public class GeographyManager
    {
        public DbGeography ConvertLatLonToDbGeography(string lon, string lat)
        {
            var point = string.Format("POINT({1} {0})", lat.Replace(',', '.'), lon).Replace(',', '.');
            return DbGeography.FromText(point);
        }

        public bool IsPointInsidePolygon(DbGeometry polygon, double longitude, double latitude) //or DbGeography in your case
        {
            DbGeometry point = DbGeometry.FromText(string.Format("POINT({0} {1})", longitude, latitude), 4326);
            return polygon.Intersects(point);
        }

        public List<NeighborhoodArea> GetAssociatedNeighborhoods(string lon, string lat)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                DbGeography point = this.ConvertLatLonToDbGeography(lon, lat);

                var neighborHoodAreas = uow.Repository<NeighborhoodArea>()
                .Query(y => y.CoordinatesGeo.Intersects(point))
                .Include(x => x.MetroArea)
                .Select()
                .ToList();

                return neighborHoodAreas;

            }
        }

        public List<NeighborhoodArea> GetAssociatedNeighborhoods(DbGeography point)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                var neighborHoodAreas = uow.Repository<NeighborhoodArea>()
                .Query(y => y.CoordinatesGeo.Intersects(point))
                .Include(x => x.MetroArea)
                .Select()
                .ToList();

                return neighborHoodAreas;

            }
        }

        public MetroArea GetAssociatedMetroArea(string lon, string lat)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                DbGeography point = this.ConvertLatLonToDbGeography(lon, lat);

                var metroArea = uow.Repository<MetroArea>()
                .Query(y => y.CoordinatesGeo.Intersects(point))
                .Select()
                .ToList()
                .FirstOrDefault();

                return metroArea;

            }
        }

        public MetroArea GetAssociatedMetroArea(DbGeography point)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                var metroArea = uow.Repository<MetroArea>()
                .Query(y => y.CoordinatesGeo.Intersects(point))
                .Select()
                .ToList()
                .FirstOrDefault();

                return metroArea;

            }
        }

        public MetroArea GetAssociatedMetroAreaByDistance(DbGeography point)
        {

            using (var context = new CDKDbContext())
            using (var uow = new UnitOfWork(context))
            {

                var metroArea = uow.Repository<MetroArea>()
                .Query(y => y.CoordinatesGeo.Distance(point) < 100000)
                .Select()
                .OrderBy(x => x.CoordinatesGeo.Distance(point))
                .ToList()
                .FirstOrDefault();

                return metroArea;

            }
        }

        public void BindAllBuildingToNeighborhood()
        {

            try
            {

                using (var context = new CDKDbContext())
                using (var uow = new UnitOfWork(context))
                {

                    var buildingAddress = uow.Repository<BuildingAddress>().Query(x => x.Lat != null || x.Lon != null).Select().ToList();

                    buildingAddress.ForEach(x => {

                        DbGeography point = this.ConvertLatLonToDbGeography(x.Lon, x.Lat);

                        var neighborHoodAreas = uow.Repository<NeighborhoodArea>()
                        .Query(y => y.CoordinatesGeo.Intersects(point))
                        .Include(z => z.MetroArea)
                        .Select()
                        .ToList();

                        if (neighborHoodAreas != null && neighborHoodAreas.Count() > 0)
                        {

                            x.MetroAreaId = neighborHoodAreas.FirstOrDefault().MetroAreaId;

                            foreach (NeighborhoodArea na in neighborHoodAreas)
                            {
                                if (na.LType == 1)
                                {
                                    x.NeighborhoodAreaFirstLevelId = na.Id;
                                }
                                else if (na.LType == 2)
                                {
                                    x.NeighborhoodAreaSecondLevelId = na.Id;
                                }
                                else if (na.LType == 3)
                                {
                                    x.NeighborhoodAreaThirdLevelId = na.Id;
                                }
                            }

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
