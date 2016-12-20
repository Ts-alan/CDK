using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class UnitMarkerViewModel
    {
        public MarkerTypeEnum Type
        {
            get;set;
        }

        public string Url
        {
            get; set;
        }

        public string BathroomTotal
        {
            get; set;
        }

        public string BedroomsTotal
        {
            get; set;
        }

        public string Price
        {
            get; set;
        }

        public string MaintenanceFee
        {
            get; set;
        }

        public string MaintenanceFeePaymentUnit
        {
            get; set;
        }

        public string ParkingSpaceTotal
        {
            get; set;
        }

        public string PricePerTime
        {
            get; set;
        }

        public List<PhotoViewModel> Photos
        {
            get; set;
        }

        public long Id
        {
            get;
            set;
        }
    }
}
