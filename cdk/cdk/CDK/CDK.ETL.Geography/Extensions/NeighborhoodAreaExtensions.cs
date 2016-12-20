using CDK.DataAccess.Models.cdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Geographpy.Extenstions
{
    public static class NeighborhoodAreaExtensions
    {

        public static List<NeighborhoodArea> SortNeighborhoodAreaByPriority(this List<NeighborhoodArea> neighborhoodArea)
        {

            List<string> priority = new List<string>(new string[] { "M", "N", "S" });

            var sortMap = priority
                .Select((x, n) => new { x, n })
                .ToDictionary(xn => xn.x, xn => xn.n);

            Func<string, int> sortFunc = n =>
            {
                if (sortMap.ContainsKey(n))
                {
                    return sortMap[n];
                }
                return int.MaxValue;
            };

            return (from i in neighborhoodArea
                    orderby sortFunc(i.NType)
                    select i).ToList();

        }

    }
}
