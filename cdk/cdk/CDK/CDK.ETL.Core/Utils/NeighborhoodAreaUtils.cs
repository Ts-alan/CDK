using CDK.DataAccess.Models.cdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Utils
{
    public static class NeighborhoodAreaUtils
    {

        public static NeighborhoodArea GetHigherLevelNeighborhood(List<NeighborhoodArea> neighborhoodAreas)
        {

            NeighborhoodArea nh = null;
            nh = neighborhoodAreas.Find(x => x.LType == 3);

            if (nh == null)
            {
                nh = neighborhoodAreas.Find(x => x.LType == 2);
            }

            if (nh == null)
            {
                nh = neighborhoodAreas.Find(x => x.LType == 1);
            }

            return nh;

        }
    }
}
