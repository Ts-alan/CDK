using CDK.BusinessLogic.Core.DTO.Client;
using CDK.BusinessLogic.Core.Extenstions;
using CDK.DataAccess.Models.ddf;
using LinqKit;
using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using CDK.DataAccess.Models.cdk;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Queries
{
    internal class BuildingQueryObject : QueryObject<Building>
    {
        private SearchCriteria Criteria
        {
            get; set;
        }

        public BuildingQueryObject(SearchCriteria criteria) : base()
        {
            this.Criteria = criteria;
        }

        public BuildingQueryObject AddUri()
        {
            this.And(x => x.BuildingUri.ToLower().Contains(this.Criteria.NormalizeNeighborhoodURI));
            return this;
        }

        public BuildingQueryObject AddInArea(List<long> areas)
        {
            this.And(x => areas.Any(a =>
            a == x.BuildingAddress.NeighborhoodAreaFirstLevelId
            || a == x.BuildingAddress.NeighborhoodAreaSecondLevelId
            || a == x.BuildingAddress.NeighborhoodAreaThirdLevelId));
            return this;
        }

        public BuildingQueryObject AddInArea(long area)
        {
            this.And(x =>
            x.BuildingAddress.NeighborhoodAreaFirstLevelId == area
            || x.BuildingAddress.NeighborhoodAreaSecondLevelId == area
            || x.BuildingAddress.NeighborhoodAreaThirdLevelId == area);
            return this;
        }

        public BuildingQueryObject OnlyWithUnits()
        {
            this.And(x => x.Units.Any());
            return this;
        }

        public BuildingQueryObject AddMinPriceCriteria()
        {
            if (this.Criteria.MinPrice.HasValue && this.Criteria.MinPrice.Value != 0)
            {
                this.And(x => x.Units.Any(u => (u.Price.HasValue && u.Price.Value >= this.Criteria.MinPrice.Value)
                || (u.Lease.HasValue && u.Lease.Value >= this.Criteria.MinPrice.Value)));
            }

            return this;
        }


        public BuildingQueryObject AddTransactionTypeCriteria()
        {
            if (this.Criteria.TransactionType == TransactionTypeEnum.ForSale)
            {
                this.And(x => x.Units.Any(u => u.TransactionType.Contains("sale")));
            }
            else
            {
                this.And(x => x.Units.Any(u => u.TransactionType.Contains("rent") || u.TransactionType.Contains("lease")));
            }

            return this;
        }

        public BuildingQueryObject AddMaxPriceCriteria()
        {
            if (this.Criteria.MaxPrice.HasValue)
            {
                this.And(x => x.Units.Any(u => (!u.Price.HasValue && u.Price.Value <= this.Criteria.MinPrice.Value)
            || (!u.Lease.HasValue && u.Lease.Value <= this.Criteria.MinPrice.Value)));
            }

            return this;
        }

        public BuildingQueryObject AddInCurrentScreenCriteria()
        {
            var currentScreen = this.Criteria.Coordinates.ConvertRectangleToCoordinatesToPolygon();

            if (currentScreen != null)
            {
                this.And(x => x.BuildingAddress.PositionGeo.Intersects(currentScreen));
            }

            return this;
        }

        public BuildingQueryObject AddBedsCriteria()
        {
            if (this.Criteria.Beds != null && this.Criteria.Beds.Any())
            {
                var predicate = PredicateBuilder.False<Building>();

                this.Criteria.Beds.ForEach(x =>
                {
                    switch (x)
                    {
                        case "studio":
                            predicate = predicate.Or(p => p.Units.Any(u => !u.BedroomsTotal.HasValue || u.BedroomsTotal.Value == 0));
                            break;

                        case "1":
                        case "2":
                        case "3":
                        case "4":
                            {
                                var beds = Convert.ToInt32(x);
                                predicate = predicate.Or(p => p.Units.Any(u => u.BedroomsTotal.HasValue && u.BedroomsTotal.Value >= beds));
                            }
                            break;

                        case "5+":
                            predicate = predicate.Or(p => p.Units.Any(u => u.BedroomsTotal.HasValue && u.BedroomsTotal.Value >= 5));
                            break;

                        default:
                            break;
                    }
                });

                this.And(predicate);
            }

            return this;
        }
    }
}