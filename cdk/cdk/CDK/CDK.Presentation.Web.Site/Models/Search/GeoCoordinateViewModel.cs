using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class GeoCoordinateViewModel
    {
        public double Latitude
        {
            get; set;
        }

        public double Longitude
        {
            get; set;
        }

        public object NormalView
        {
            get
            {
                return new
                {
                    lat = this.Latitude,
                    lng = this.Longitude
                };
            }
        }
    }
}
