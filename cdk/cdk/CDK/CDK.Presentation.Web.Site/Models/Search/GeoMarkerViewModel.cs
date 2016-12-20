using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class GeoMarkerViewModel
    {
        public MarkerTypeEnum Type
        {
            get; set;
        }

        public int Count
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        [ScriptIgnore(ApplyToOverrides = true)]
        [IgnoreDataMember]
        public GeoCoordinateViewModel Position
        {
            get; set;
        }

        public object NormalView
        {
            get
            {
                return new
                {
                    lat = this.Position.Latitude,
                    lng = this.Position.Longitude
                };
            }
        }

        public long Id
        {
            get; set;
        }
    }
}
