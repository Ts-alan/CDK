using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class GeoPolygon
    {
        public long? Id
        {
            get; set;
        }

        public bool IsActive
        {
            get;set;
        }

        public GeoCoordinate Center
        {
            get; set;
        }

        public List<GeoCoordinate> Coordinates
        {
            get;set;
        }
    }
}
