using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.UnitOfWork;
using client = CDK.BusinessLogic.Core.DTO.Client;
using db = CDK.DataAccess.Models;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces;
using CDK.BusinessLogic.Core.Extenstions;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Queries;
using CDK.DataAccess.Repositories.Migrations;
using LinqKit;
using CDK.BusinessLogic.Core.DTO.DetailObject;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client
{
    internal class ClientSearchService : BaseApplicationService, IClientSearchService
    {
        public ClientSearchService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        public client.Area FindAreaBySluggedValue(string value)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var result = uow.Repository<db.cdk.MetroArea>()
                    .Query(x => x.MetroAreaUri.ToLower() == value.ToLower())
                    .Select()
                    .FirstOrDefault();

                return result == null ? null : this.Mapper.Map<db.cdk.MetroArea, client.Area>(result);
            });
        }

        public IList<client.Area> FindAreas(string searchCriteria, int take = 10)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var criteria = searchCriteria.ToLower().Trim();
                var total = 0;

                var query = uow.Repository<db.cdk.MetroArea>()
                        .Query(x => x.Name.ToLower().Contains(criteria) || x.ShortName.ToLower().Contains(criteria))
                        .OrderBy(x => x.OrderBy(y => y.Name));

                var resultList = Enumerable.Empty<db.cdk.MetroArea>();

                if (take > 0)
                {
                    resultList = query.SelectPage(1, take, out total);
                }
                else
                {
                    resultList = query.Select();
                }

                var result =
                    this.Mapper.Map<IList<db.cdk.MetroArea>, IList<client.Area>>(
                         resultList.ToList());

                return result;
            });
        }

        public IList<client.Area> GetPopularAreas()
        {
            var ids = (System.Configuration.ConfigurationManager.AppSettings["popularAreas"] ?? "").Split(';');

            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var result = this.Mapper.Map<IList<db.cdk.MetroArea>, IList<client.Area>>(
                    uow.Repository<db.cdk.MetroArea>()
                        .Query(x => ids.Any(y => y == x.MetroAreaExtId.ToString()))
                        .OrderBy(x => x.OrderBy(y => y.Name))
                        .Select()
                        .ToList());

                return result;
            });

        }

        public IList<client.Neighborhood> FindNeighborhoodArea(long areaId, string searchQuery, int take = 10)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var criteria = searchQuery.ToLower().Trim();
                var total = 0;
                var result =
                    this.Mapper.Map<IList<db.cdk.NeighborhoodArea>, IList<client.Neighborhood>>(
                        uow.Repository<db.cdk.NeighborhoodArea>()
                            .Query(
                                x =>
                                    x.MetroAreaId == areaId &&
                                    (x.Name.ToLower().Contains(criteria) || x.ShortName.ToLower().Contains(criteria)))
                            .OrderBy(a => a.OrderBy(x => x.Name))
                            .SelectPage(1, take, out total)
                            .ToList());


                return result;
            });
        }

        public IList<client.Neighborhood> FindNeighborhoodArea(string stateName, string areaName, string searchQuery,
            int take = 10)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var criteria = searchQuery.ToLower().Trim();
                var metroArea = string.Format(@"{0}/{1}", stateName.ToLower().Trim(), areaName.ToLower().Trim());
                var total = 0;

                var result = uow.Repository<db.cdk.NeighborhoodArea>()
                    .Query(x =>
                        x.MetroArea.MetroAreaUri.ToLower().Equals(metroArea)
                        && (x.Name.ToLower().Contains(criteria) || x.ShortName.ToLower().Contains(criteria)))
                    .OrderBy(a => a.OrderBy(x => x.Name))
                    .SelectPage(1, take, out total)
                    .ToList();


                return this.Mapper.Map<IList<db.cdk.NeighborhoodArea>, IList<client.Neighborhood>>(result);
            });
        }


        public client.Neighborhood FindNeighborhoodBySluggedValue(string value)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var result = uow.Repository<db.cdk.NeighborhoodArea>()
                    .Query(x => x.NeighborhoodAreaUri.ToLower() == value.ToLower())
                    .Select()
                    .FirstOrDefault();

                return result == null ? null : this.Mapper.Map<db.cdk.NeighborhoodArea, client.Neighborhood>(result);
            });
        }
                                  
        private static string NormalizeURI(string state, string area, string nNeighborhood, string mNeighborhood,
            string sNeighborhood)
        {
            var metroArea = string.Format(@"{0}/{1}", (state ?? "").ToLower().Trim(), (area ?? "").ToLower().Trim());

            var nAreaUrl = metroArea;

            if (!string.IsNullOrEmpty(nNeighborhood))
            {
                var neighborhoodArea =
                    new StringBuilder(string.Format(@"{0}/{1}", metroArea,
                        (nNeighborhood ?? string.Empty).ToLower().Trim()));

                if (!string.IsNullOrEmpty(mNeighborhood))
                {

                    neighborhoodArea.AppendFormat(@"/{0}", mNeighborhood);

                    if (!string.IsNullOrEmpty(sNeighborhood))
                    {
                        neighborhoodArea.AppendFormat(@"/{0}", sNeighborhood);
                    }
                }

                nAreaUrl = neighborhoodArea.ToString();
            }

            return nAreaUrl;
        }

        public object GetDetails(string searchString)
        {


            return this.InvokeInUnitOfWorkScope(uow =>
            {

                var building = uow.Repository<db.ddf.Building>()
                    .Query(a => a.BuildingUri == searchString)
                    .Include(x => x.Units).Include(x => x.Units.Select(a =>
                        a.UnitPhotos))
                    .Include(x => x.BuildingAddress).Include(x => x.Amenities)
                    .Select().FirstOrDefault();

                if (building != null)
                {
                    var nArea =
                   uow.Repository<db.cdk.NeighborhoodArea>()
                       .Query(a => 
                       building.BuildingAddress.NeighborhoodAreaFirstLevelId == a.Id
                       || building.BuildingAddress.NeighborhoodAreaSecondLevelId == a.Id
                       || building.BuildingAddress.NeighborhoodAreaThirdLevelId == a.Id)
                       .Include(a => a.NeighborhoodGuides)
                       .Select()
                     .FirstOrDefault();

                   var result = Mapper.Map<Tuple<CDK.DataAccess.Models.ddf.Building, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                        CDK.BusinessLogic.Core.DTO.DetailObject.Building>(Tuple.Create<CDK.DataAccess.Models.ddf.Building, CDK.DataAccess.Models.cdk.NeighborhoodArea>(building, nArea));
                   return (object)result;
                }

                var unit = uow.Repository<db.ddf.Unit>().Query(a => a.UnitUri == searchString)
                .Include(a => a.Building.BuildingAddress).Include(a => a.Building).Include(a => a.Features).Include(a => a.UnitPhotos).Select()
                    .FirstOrDefault();
                if (unit != null)
                {
                  
                    var nArea = uow.Repository<db.cdk.NeighborhoodArea>()
                        .Query(a =>
                       unit.Building.BuildingAddress.NeighborhoodAreaFirstLevelId == a.Id
                       || unit.Building.BuildingAddress.NeighborhoodAreaSecondLevelId == a.Id
                       || unit.Building.BuildingAddress.NeighborhoodAreaThirdLevelId == a.Id)
                        .Include(a => a.NeighborhoodGuides)
                        .Select().FirstOrDefault();
                    var result = Mapper.Map <Tuple<CDK.DataAccess.Models.ddf.Unit, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                      CDK.BusinessLogic.Core.DTO.DetailObject.Unit>(Tuple.Create <CDK.DataAccess.Models.ddf.Unit, CDK.DataAccess.Models.cdk.NeighborhoodArea> (unit, nArea));
               
                    return result;
                }
                return null;

            });
        }
        public object GetDetails(int id, DTO.Client.MarkerEntityEnum type)
        {


            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (type == DTO.Client.MarkerEntityEnum.Building)
                {
                    var building = uow.Repository<db.ddf.Building>()
                        .Query(a => a.Id == id)
                        .Include(x => x.Units).Include(x => x.Units.Select(a =>
                            a.UnitPhotos))
                        .Include(x => x.BuildingAddress).Include(x => x.Amenities)
                        .Select().FirstOrDefault();

                    if (building != null)
                    {
                        var nArea =
                            uow.Repository<db.cdk.NeighborhoodArea>()
                                .Query(a =>
                       building.BuildingAddress.NeighborhoodAreaFirstLevelId == a.Id
                       || building.BuildingAddress.NeighborhoodAreaSecondLevelId == a.Id
                       || building.BuildingAddress.NeighborhoodAreaThirdLevelId == a.Id)
                                .Include(a => a.NeighborhoodGuides)
                                .Select()
                                .FirstOrDefault();


                       var result = Mapper.Map<Tuple<CDK.DataAccess.Models.ddf.Building, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                       CDK.BusinessLogic.Core.DTO.DetailObject.Building>(Tuple.Create<CDK.DataAccess.Models.ddf.Building, CDK.DataAccess.Models.cdk.NeighborhoodArea>(building, nArea));

                        return (object)result;
                    }
                }
                var unit = uow.Repository<db.ddf.Unit>().Query(a => a.Id == id).Include(a => a.Building.BuildingAddress)
                .Include(a => a.Building).Include(a => a.Features).Include(a => a.UnitPhotos).Select()
                    .FirstOrDefault();
                if (unit != null)
                {

                    var nArea = uow.Repository<db.cdk.NeighborhoodArea>()
                        .Query(a =>
                       unit.Building.BuildingAddress.NeighborhoodAreaFirstLevelId == a.Id
                       || unit.Building.BuildingAddress.NeighborhoodAreaSecondLevelId == a.Id
                       || unit.Building.BuildingAddress.NeighborhoodAreaThirdLevelId == a.Id)
                        .Include(a => a.NeighborhoodGuides)
                        .Select().FirstOrDefault();
                    var result = Mapper.Map<Tuple<CDK.DataAccess.Models.ddf.Unit, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                     CDK.BusinessLogic.Core.DTO.DetailObject.Unit>(Tuple.Create<CDK.DataAccess.Models.ddf.Unit, CDK.DataAccess.Models.cdk.NeighborhoodArea>(unit, nArea));
                    return result;
                }
                return null;
            });
        }
    }
}