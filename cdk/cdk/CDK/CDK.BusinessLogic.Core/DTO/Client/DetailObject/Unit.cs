using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.DetailObject
{
    class Unit
    {
        public string Id
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
        public string Parking
        {
            get; set;
        }

        public string LeasePerTime
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
        public decimal? Price
        {
            get; set;
        }
        public int DaysOnMarket
        {
            get; set;
        }
        public decimal? MaintenanceFee
        {
            get; set;
        }
        public string TransactionType
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
        public string Neighborhood
        {
            get; set;
        }
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
        public ICollection<NeighborhoodGuide> NeighborhoodGuide
        {
            get; set;
        }
        public List<DTO.Client.Photo> Photo
        { get; set; }

      
        public string UrlForPage
        { get; set; }
    }
}
