using CDK.BusinessLogic.Core.DTO.Client;
using CDK.DataAccess.Models.ddf;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Queries
{
    internal static class UnitSubSeachQuery
    {
        public static IQueryable<Unit> AddMinPriceCriteria(
            this IQueryable<Unit> units,
            SearchCriteria criteria)
        {
            if (criteria.MinPrice.HasValue && criteria.MinPrice.Value != 0)
            {
                return units.Where(u => (u.Price.HasValue && u.Price.Value >= criteria.MinPrice.Value)
                || (u.Lease.HasValue && u.Lease.Value >= criteria.MinPrice.Value));
            }

            return units;
        }

        public static IQueryable<Unit> AddInArea(this IQueryable<Unit> units, long area)
        {
            return units.Where(x => area == x.Building.BuildingAddress.NeighborhoodAreaFirstLevelId
            || area == x.Building.BuildingAddress.NeighborhoodAreaSecondLevelId
            || area == x.Building.BuildingAddress.NeighborhoodAreaThirdLevelId);
        }


        public static IQueryable<Unit> AddMaxPriceCriteria(
            this IQueryable<Unit> units,
            SearchCriteria criteria)
        {
            if (!criteria.MaxPrice.HasValue)
            {
                return units;
            }

            return units.Where(u => (u.Price.HasValue && u.Price.Value <= criteria.MinPrice.Value) 
            || (u.Lease.HasValue && u.Lease.Value <= criteria.MinPrice.Value));
        }


        public static IQueryable<Unit> AddTransactionTypeCriteria(
            this IQueryable<Unit> units,
            SearchCriteria criteria)
        {
            return units.Where(u =>
            criteria.TransactionType == TransactionTypeEnum.ForSale
            ? u.TransactionType.Contains("sale")
            : (u.TransactionType.Contains("rent") || u.TransactionType.Contains("lease")));
        }

        public static IQueryable<Unit> AddBedsCriteria(
            this IQueryable<Unit> units,
            SearchCriteria criteria)
        {
            if (criteria.Beds != null && criteria.Beds.Any())
            {
                var predicate = PredicateBuilder.False<Unit>();

                criteria.Beds.ForEach(x =>
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

                return units.Where(predicate);
            }

            return units;
        }
    }
}
