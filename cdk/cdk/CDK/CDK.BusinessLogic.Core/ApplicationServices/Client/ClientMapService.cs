using CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces;
using CDK.BusinessLogic.Core.ApplicationServices.Client.Queries;
using CDK.BusinessLogic.Core.DTO.Client;
using CDK.BusinessLogic.Core.Extenstions;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

using client = CDK.BusinessLogic.Core.DTO.Client;

using db = CDK.DataAccess.Models;
using CDK.DataAccess.Models.cdk;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client
{
    internal class ClientMapService : BaseApplicationService, IClientMapService
    {
        protected readonly IClientSearchService SearchService;

        public ClientMapService(IUnitOfWorkAsync unitOfWork, IClientSearchService search) : base(unitOfWork)
        {
            this.SearchService = search;
        }

        public string GeoJSON(SearchCriteria criteria)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var mArea = uow.Repository<db.cdk.MetroArea>()
                    .Query(x => x.MetroAreaUri.ToLower() == criteria.NormalizeMetroURI)
                    .Select()
                    .FirstOrDefault();

                return mArea == null ? null : mArea.CoordinatesAsText;
            });
        }

        public IList<GeoPolygon> Polygons(SearchCriteria criteria)
        {
            if (string.IsNullOrEmpty(criteria.NNeighborhood))
            {
                return this.InvokeInUnitOfWorkScope(uow =>
                {
                    var mArea = uow.Repository<db.cdk.MetroArea>()
                        .Query(x => x.MetroAreaUri.ToLower() == criteria.NormalizeMetroURI)
                        .Select()
                        .FirstOrDefault();
                    return mArea == null ? null : new List<GeoPolygon> { this.Mapper.Map<db.cdk.MetroArea, client.GeoPolygon>(mArea) };
                });
            }

            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var repo = uow.Repository<db.cdk.NeighborhoodArea>();
                var result = new List<GeoPolygon>();

                var query = repo
                    .Query(x => x.NeighborhoodAreaUri.ToLower().Contains(criteria.NormalizeMetroURI));

                if (criteria.CoordinatesGeo != null)
                {
                    query = repo
                    .Query(x =>
                    x.NeighborhoodAreaUri.ToLower().Contains(criteria.NormalizeMetroURI)
                    && x.CoordinatesGeo.Intersects(criteria.CoordinatesGeo));
                }

                var geos = query
                 .Select(x => x.CoordinatesGeo)
                 .ToList();

                result.AddRange(geos.Select(x => new GeoPolygon
                {
                    Id = -1,
                    Coordinates = x.GetGeoCoordinatesFromPolygon().ToList(),
                    IsActive = false
                }));

                return result;
            });
        }

        public GeoPolygon Center(SearchCriteria criteria)
        {
            if (string.IsNullOrEmpty(criteria.NNeighborhood))
            {
                return this.InvokeInUnitOfWorkScope(uow =>
                {
                    var result = uow.Repository<db.cdk.MetroArea>()
                        .Query(x => x.MetroAreaUri.ToLower() == criteria.NormalizeMetroURI)
                        .Select()
                        .FirstOrDefault();

                    return result == null ? null : this.Mapper.Map<db.cdk.MetroArea, client.GeoPolygon>(result);
                });
            }

            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var result = uow.Repository<db.cdk.NeighborhoodArea>()
                    .Query(x => x.NeighborhoodAreaUri.ToLower() == criteria.NormalizeNeighborhoodURI)
                    .Select()
                    .FirstOrDefault();

                return result == null ? null : this.Mapper.Map<db.cdk.NeighborhoodArea, client.GeoPolygon>(result);
            });
        }

        public IList<client.GeoMarker> Markers(client.SearchCriteria criteria)
        {
            var result = new List<client.GeoMarker>();

            if (string.IsNullOrEmpty(criteria.Area) || string.IsNullOrEmpty(criteria.State))
            {
                return result;
            }

            try
            {
                this.BuildMarkerList(criteria, result);
            }
            catch
            {
                result = Enumerable.Empty<client.GeoMarker>().ToList();
            }

            return result;
        }

        public Tuple<long, string> CenterData(SearchCriteria criteria)
        {
            if (string.IsNullOrEmpty(criteria.NNeighborhood))
            {
                return this.InvokeInUnitOfWorkScope(uow =>
                {
                    var result = uow.Repository<db.cdk.MetroArea>()
                        .Query(x => x.MetroAreaUri.ToLower() == criteria.NormalizeMetroURI)
                        .Select()
                        .FirstOrDefault();

                    return result == null ? null : new Tuple<long, string>(result.Id, null);
                });
            }

            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var result = uow.Repository<db.cdk.NeighborhoodArea>()
                    .Query(x => x.NeighborhoodAreaUri.ToLower() == criteria.NormalizeNeighborhoodURI)
                    .Select()
                    .FirstOrDefault();

                return result == null ? null : new Tuple<long, string>(result.Id, result.NType);
            });
        }


        public object InfoWindowData(SearchCriteria criteria, long objectId)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var building = uow.Repository<db.ddf.Building>()
                        .Query(a => a.Id == objectId)
                        .Include(x => x.Units)
                        .Include(x => x.Units.Select(a => a.UnitPhotos))
                        .Include(x => x.BuildingAddress)
                        .Include(x => x.Amenities)
                        .Select()
                        .FirstOrDefault();

                if (building == null)
                {
                    return (object)null;
                }

                var units = building.Units
                                    .AsQueryable()
                                    .AddBedsCriteria(criteria)
                                    .AddMinPriceCriteria(criteria)
                                    .AddMaxPriceCriteria(criteria)
                                    .AddTransactionTypeCriteria(criteria)
                                    .ToList();
                var result = Mapper.Map<Tuple<CDK.DataAccess.Models.ddf.Building, IList<CDK.DataAccess.Models.ddf.Unit>>,
                    CDK.BusinessLogic.Core.DTO.DetailObject.Building>(Tuple.Create<CDK.DataAccess.Models.ddf.Building,
                                                                              IList<CDK.DataAccess.Models.ddf.Unit>>(building, units));
                return result;
            });
        }

        public object ListViewResult(SearchCriteria criteria)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var unitQuery = uow.Repository<db.ddf.Unit>()
                 .Query((new UnitQueryObject(criteria))
                 .AddUri()
                 .AddInCurrentScreenCriteria()
                 .AddBedsCriteria()
                 .AddMinPriceCriteria()
                 .AddMaxPriceCriteria()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.Building)
                 .Include(x => x.Building.BuildingAddress)
                 .Include(x => x.UnitPhotos);

                var totalCount = 0;

                if (criteria.SortBy == SortByUnitTypeEnum.Price)
                {
                    unitQuery = unitQuery
                        .OrderBy(x => x.OrderBy(z => z.Price));
                }
                else
                {
                    unitQuery
                        .OrderBy(x => x.OrderBy(z => z.LastUpdate));
                }

                var units = unitQuery
                .SelectPage(criteria.Page.HasValue ? criteria.Page.Value : 1, 12, out totalCount)
                .ToList();

                return new ListUnit
                {
                    Units = Mapper.Map<List<db.ddf.Unit>, List<DTO.Client.UnitForGallery>>(units),
                    TotalCount = totalCount,

                };
            });
        }

        public object GalleryViewResult(SearchCriteria criteria)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var unitQuery = uow.Repository<db.ddf.Unit>()
                 .Query((new UnitQueryObject(criteria))
                 .AddUri()
                 .AddBedsCriteria()
                 .AddMinPriceCriteria()
                 .AddMaxPriceCriteria()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.Building)
                 .Include(x => x.Building.BuildingAddress)
                 .Include(x => x.UnitPhotos);

                var totalCount = 0;

                if (criteria.SortBy == SortByUnitTypeEnum.Price)
                {
                    unitQuery = unitQuery
                        .OrderBy(x => x.OrderBy(z => z.Price));
                }
                else
                {
                    unitQuery
                        .OrderBy(x => x.OrderBy(z => z.LastUpdate));
                }
                var units = unitQuery
                .SelectPage(criteria.Page.HasValue ? criteria.Page.Value : 1, 12, out totalCount).ToList();


              

                return new ListUnit
                {
                    Units = Mapper.Map<List<db.ddf.Unit>, List<DTO.Client.UnitForGallery>>(units),
                    TotalCount = totalCount,

                };
            });
        }

        public object GetStringForGallery(SearchCriteria criteria)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var unitsTotal = uow.Repository<db.ddf.Unit>()
                 .Query((new UnitQueryObject(criteria))
                 .AddInMetroArea()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.Building)
                 .Include(x => x.Building.BuildingAddress)
                 .Select()
                 .Count();

                var metroArea = uow.Repository<db.cdk.MetroArea>()
                .Query(x => x.MetroAreaUri.Contains(criteria.NormalizeMetroURI))
                .Select(x => x.ShortName)
                .FirstOrDefault();
             
                return new
                {
                    TotalCount= unitsTotal,
                    NameArea= metroArea,
                    TransactionType = criteria.TransactionType.ToString()
                };
            });
        }

        #region Private

        private void BuildMarkerList(SearchCriteria criteria, List<GeoMarker> result)
        {
            if (criteria.Zoom > 15)
            {
                this.BuildingMarkers(criteria, result);
            }

            if (criteria.Zoom <= 12)
            {
                this.MetroAreaCluster(criteria, result);
            }

            if (criteria.Zoom > 12 && criteria.Zoom <= 15)
            {
                this.NeighborhoodAreaClusters(criteria, result);
            }
        }

        private void MetroAreaCluster(SearchCriteria criteria, List<GeoMarker> result)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var mArea = uow.Repository<db.cdk.MetroArea>()
                  .Query(x => x.MetroAreaUri.ToLower() == criteria.NormalizeMetroURI)
                  .Select()
                  .FirstOrDefault();

                if (mArea != null)
                {
                    result.Add(new client.GeoMarker
                    {
                        Position = new client.GeoCoordinate(mArea.CenterPointLat, mArea.CenterPointLon),
                        Count = this.GetMarkersCount(criteria),
                        Id = mArea.Id,
                        Type = client.MarkerEntityEnum.Cluster,
                        Title = mArea.Name
                    });
                }
            });
        }

        private void NeighborhoodAreaClusters(SearchCriteria criteria, List<GeoMarker> result)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var nAreas = uow.Repository<db.cdk.NeighborhoodArea>()
                  .Query((new NeighborhoodAreaQueryObject(criteria))
                  .AddInMetroArea()
                  .AddInCurrentScreenCriteria()
                  .AddZoomLevel())
                  .Select()
                  .ToList();

                if (nAreas.Any())
                {
                    var countDictionary = this.GetMarkersCount(nAreas.Select(x => x.Id).ToList(), criteria);

                    var count = 0;

                    result.AddRange(nAreas
                        .Select(x => new client.GeoMarker
                        {
                            Position = new client.GeoCoordinate(x.CenterPointLat, x.CenterPointLon),
                            Count = countDictionary.TryGetValue(x.Id, out count) ? count : 0,
                            Id = x.Id,
                            Type = client.MarkerEntityEnum.Cluster,
                            Title = x.Name
                        }));
                }
            });
        }

        private void BuildingMarkers(SearchCriteria criteria, List<GeoMarker> result)
        {
            this.InvokeInUnitOfWorkScope(uow =>
            {
                var buildingsQuery = uow.Repository<db.ddf.Building>()
                 .Query((new BuildingQueryObject(criteria))
                 .AddUri()
                 .AddInCurrentScreenCriteria()
                 .OnlyWithUnits()
                 .AddBedsCriteria()
                 .AddMinPriceCriteria()
                 .AddMaxPriceCriteria()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.BuildingAddress)
                 .Include(x => x.Units);

                var buildings = buildingsQuery.Select().ToList();

                foreach (var building in buildings)
                {
                    var units = building.Units
                                    .AsQueryable()
                                    .AddBedsCriteria(criteria)
                                    .AddMinPriceCriteria(criteria)
                                    .AddMaxPriceCriteria(criteria)
                                    .AddTransactionTypeCriteria(criteria)
                                    .ToList();
                    if (units.Any())
                    {
                        var marker = new client.GeoMarker
                        {
                            Position = new client.GeoCoordinate(building.BuildingAddress.Lat, building.BuildingAddress.Lon),
                            Count = units.Count(),
                            Id = building.Id,
                            Type = client.MarkerEntityEnum.Building,
                            Title = building.BuildingUri
                        };

                        result.Add(marker);
                    }
                }
            });
        }

        private int GetMarkersCount(SearchCriteria criteria)
        {
            var count = 0;

            this.InvokeInUnitOfWorkScope(uow =>
            {
                var buildingsQuery = uow.Repository<db.ddf.Building>()
                 .Query((new BuildingQueryObject(criteria))
                 .AddUri()
                 .OnlyWithUnits()
                 .AddBedsCriteria()
                 .AddMinPriceCriteria()
                 .AddMaxPriceCriteria()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.BuildingAddress)
                 .Include(x => x.Units);

                var buildings = buildingsQuery.Select().ToList();

                foreach (var building in buildings)
                {
                    var units = building.Units
                                    .AsQueryable()
                                    .AddBedsCriteria(criteria)
                                    .AddMinPriceCriteria(criteria)
                                    .AddMaxPriceCriteria(criteria)
                                    .AddTransactionTypeCriteria(criteria)
                                    .Count();

                    count += units;
                }
            });

            return count;
        }

        private Dictionary<long, int> GetMarkersCount(List<long> areas, SearchCriteria criteria)
        {
            var count = new Dictionary<long, int>();

            this.InvokeInUnitOfWorkScope(uow =>
            {
                var units = uow.Repository<db.ddf.Unit>()
                 .Query((new UnitQueryObject(criteria))
                 .AddUri()
                 .AddInCurrentScreenCriteria()
                 .AddInArea(areas)
                 .AddBedsCriteria()
                 .AddMinPriceCriteria()
                 .AddMaxPriceCriteria()
                 .AddTransactionTypeCriteria())
                 .Include(x => x.Building)
                 .Include(x => x.Building.BuildingAddress).Select().ToList();


                foreach (var area in areas)
                {
                    count.Add(area, units.AsQueryable().AddInArea(area).Count());
                }
            });

            return count;
        }

        #endregion Private
    }
}