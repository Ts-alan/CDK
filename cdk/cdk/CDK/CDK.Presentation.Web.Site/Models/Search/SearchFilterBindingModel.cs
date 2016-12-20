using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Models.Search
{
    public class SearchFilterBindingModel
    {
        public string State
        {
            get; set;
        }
        public string Area
        {
            get; set;
        }
        public string NNeighborhood
        {
            get; set;
        }
        public string MNeighborhood
        {
            get; set;
        }
        public string SNeighborhood
        {
            get; set;
        }
        public List<string> Beds
        {
            get; set;
        }
        public decimal? MinPrice
        {
            get; set;
        }
        public decimal? MaxPrice
        {
            get; set;
        }
        public int? Take
        {
            get; set;
        }
        public int? Page
        {
            get; set;
        }
        public int? Skip
        {
            get; set;
        }
      
        public SortByUnitTypeEnum SortBy
        {
            get; set;
        }
        public List<GeoCoordinateViewModel> Coordinates
        {
            get; set;
        }    
        public int? Zoom
        {
            get; set;
        }

        public TransactionTypeEnum TransactionType
        {
            get;set;
        }
    }
}
