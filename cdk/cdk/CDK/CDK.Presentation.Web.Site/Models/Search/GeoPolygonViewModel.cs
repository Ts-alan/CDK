using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class GeoPolygonViewModel
    {
        public long? Id
        {
            get;set;
        }

        public bool IsActive
        {
            get; set;
        }

        public GeoCoordinateViewModel Center
        {
            get; set;
        }

        [ScriptIgnore(ApplyToOverrides = true)]
        [IgnoreDataMember]
        public virtual List<GeoCoordinateViewModel> Coordinates
        {
            get; set;
        }

        public IEnumerable<object> NormalView
        {
            get
            {
                return this.Coordinates.Select(x => x.NormalView).ToList();
            }
        }
    }
}
