using CDK.BusinessLogic.Core.Extenstions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.DTO.Client
{
    public class SearchCriteria
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
        public List<GeoCoordinate> Coordinates
        {
            get; set;
        }
        public int? Zoom
        {
            get; set;
        }
        public SortByUnitTypeEnum SortBy
        {
            get; set;
        }

        public DbGeography CoordinatesGeo
        {
            get
            {
                return this.Coordinates.ConvertRectangleToCoordinatesToPolygon();
            }
        }

        public TransactionTypeEnum TransactionType
        {
            get; set;
        }

        public string NormalizeNeighborhoodURI
        {
            get

            {
                var metroArea = this.NormalizeMetroURI;

                var nAreaUrl = metroArea;

                if (!string.IsNullOrEmpty(this.NNeighborhood))
                {
                    var neighborhoodArea = new StringBuilder(string.Format(@"{0}/{1}", metroArea, (this.NNeighborhood ?? string.Empty).ToLower().Trim()));

                    if (!string.IsNullOrEmpty(this.MNeighborhood))
                    {

                        neighborhoodArea.AppendFormat(@"/{0}", this.MNeighborhood);

                        if (!string.IsNullOrEmpty(this.SNeighborhood))
                        {
                            neighborhoodArea.AppendFormat(@"/{0}", this.SNeighborhood);
                        }
                    }

                    nAreaUrl = neighborhoodArea.ToString();
                }

                return nAreaUrl;
            }
        }

        public string NormalizeMetroURI
        {
            get
            {
                var metroArea = string.Format(@"{0}/{1}", (this.State ?? "").ToLower().Trim(), (this.Area ?? "").ToLower().Trim());

                return metroArea;
            }
        }

    }
}
