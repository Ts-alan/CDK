using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class GetBuildingViewModel
    {
        public string StreetAddress
        {
            get; set;
        }
        public string PostalCode
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
        public string Country
        {
            get; set;
        }

    }
}