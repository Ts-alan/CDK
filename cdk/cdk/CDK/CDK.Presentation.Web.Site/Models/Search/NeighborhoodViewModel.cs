using System;
using System.Collections.Generic;     
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class NeighborhoodViewModel
    {
        public string Value
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Group
        {
            get;
            set;
        }

        public GeoCoordinateViewModel Center
        {
            get; set;
        }
    }
}
