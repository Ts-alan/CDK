using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.DetailObject
{
    class Building
    {
        public long Id
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public string Latitude
        {
            get; set;
        }
        public string Longitude
        {
            get; set;
        }
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
        public string Neighborhood
        {
            get; set;
        }
        public string ConstructedDate
        {
            get; set;
        }
        public IEnumerable<string> Amenities
        {
            get; set;
        }
        public string SeoDescription
        {
            get; set;
        }

        public ICollection<NeighborhoodGuide> NeighborhoodGuide
        {
            get; set;
        }

        public string UrlForPage
        { get; set; }

        public List<Unit> Units
        { get; set; }
        public List<DTO.Client.Photo> Photo
        { get; set; }

        public string SeoTitle
        {
            get; set;
        }
        public string SeoKeywords
        {
            get; set;
        }
        public string SeoMetaDescription
        {
            get; set;
        }
    }
}
