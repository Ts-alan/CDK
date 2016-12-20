using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    class UnitForGallery
    {
        public string UrlForPage
        {
            get; set;
        }

        public decimal? Price
        {
            get; set;
        }

        public DTO.Client.Photo Photo
        {
            get; set;
        }
        public int? Bed
        {
            get; set;
        }
        public int? Bath
        {
            get; set;
        }
        public string StreetAddress
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
    }
}
