using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class GeoMarker
    {
        public MarkerEntityEnum Type
        {
            get; set;
        }
             
        public int Count
        {
            get; set;
        }

        public GeoCoordinate Position
        {
            get; set;
        }   

        public long Id
        {
            get; set;
        }

        public string Title
        {
            get;set;
        }
    }
}
