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
    internal class UnitQueryObject : QueryObject<Unit>
    {
        private SearchCriteria Criteria
        {
            get; set;
        }

        public UnitQueryObject(SearchCriteria criteria) : base()
        {
            this.Criteria = criteria;
        }

        public UnitQueryObject AddUri()
        {
            this.And(x => x.UnitUri.ToLower().Contains(this.Criteria.NormalizeNeighborhoodURI));
            return this;
        }

        public UnitQueryObject AddInMetroArea()
        {
            this.And(x => x.UnitUri.ToLower().Contains(this.Criteria.NormalizeMetroURI));
            return this;
        }

        public UnitQueryObject AddInArea(List<long> areas)
        {
            this.And(x => areas.Any(a => a == x.Building.BuildingAddress.NeighborhoodAreaFirstLevelId
            || a == x.Building.BuildingAddress.NeighborhoodAreaSecondLevelId
            || a == x.Building.BuildingAddress.NeighborhoodAreaThirdLevelId));
            return this;
        }


        public UnitQueryObject AddMinPriceCriteria()
        {
            if (this.Criteria.MinPrice.HasValue && this.Criteria.MinPrice.Value != 0)
            {
                this.And(u => (u.Price.HasValue && u.Price.Value >= this.Criteria.MinPrice.Value) 
                ||(u.Lease.HasValue && u.Lease.Value >= this.Criteria.MinPrice.Value));
            }

            return this;
        }

        public UnitQueryObject AddMaxPriceCriteria()
        {
            if (this.Criteria.MaxPrice.HasValue)
            {
                this.And(u => (u.Price.HasValue && u.Price.Value <= this.Criteria.MinPrice.Value)
            || (u.Lease.HasValue && u.Lease.Value <= this.Criteria.MinPrice.Value));
            }

            return this;
        }

        public UnitQueryObject AddTransactionTypeCriteria()
        {
            if (this.Criteria.TransactionType == TransactionTypeEnum.ForSale)
            {
                this.And(u => u.TransactionType.Contains("sale"));
            }
            else
            {
                this.And(u => u.TransactionType.Contains("rent") || u.TransactionType.Contains("lease"));
            }

            return this;
        }

        public UnitQueryObject AddInCurrentScreenCriteria()
        {
            var currentScreen = this.Criteria.Coordinates.ConvertRectangleToCoordinatesToPolygon();

            if (currentScreen != null)
            {
                this.And(x => x.Building.BuildingAddress.PositionGeo.Intersects(currentScreen));
            }

            return this;
        }

        public UnitQueryObject AddBedsCriteria()
        {
            if (this.Criteria.Beds != null && this.Criteria.Beds.Any())
            {
                var predicate = PredicateBuilder.False<Unit>();

                this.Criteria.Beds.ForEach(x =>
                {
                    switch (x)
                    {
                        case "studio":
                            predicate = predicate.Or(u => !u.BedroomsTotal.HasValue || u.BedroomsTotal.Value == 0);
                            break;

                        case "1":
                        case "2":
                        case "3":
                        case "4":
                            {
                                var beds = Convert.ToInt32(x);
                                predicate = predicate.Or(u => u.BedroomsTotal.HasValue && u.BedroomsTotal.Value >= beds);
                            }
                            break;

                        case "5+":
                            predicate = predicate.Or(u => u.BedroomsTotal.HasValue && u.BedroomsTotal.Value >= 5);
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