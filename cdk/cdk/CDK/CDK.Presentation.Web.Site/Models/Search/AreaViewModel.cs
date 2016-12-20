using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class AreaViewModel
    {
        public string Group
        {
            get;
            set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }


        public string Value
        {
            get; set;
        }

        public GeoCoordinateViewModel Center
        {
            get; set;
        }
    }
}
