using CDK.BusinessLogic.Core.DTO.Client;
using CDK.BusinessLogic.Core.Extenstions;
using CDK.DataAccess.Models.cdk;
using Repository.Pattern.Ef6;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Queries
{
    internal class NeighborhoodAreaQueryObject : QueryObject<NeighborhoodArea>
    {
        private SearchCriteria Criteria
        {
            get; set;
        }

        public NeighborhoodAreaQueryObject(SearchCriteria criteria) : base()
        {
            this.Criteria = criteria;
        }

        public NeighborhoodAreaQueryObject AddInCurrentScreenCriteria()
        {
            var currentScreen = this.Criteria.Coordinates.ConvertRectangleToCoordinatesToPolygon();

            if (currentScreen != null)
            {
                this.And(x => x.CenterPointGeo.Intersects(currentScreen));
            }

            return this;
        }

        public NeighborhoodAreaQueryObject AddInMetroArea()
        {
            this.And(x => x.NeighborhoodAreaUri.ToLower().Contains(this.Criteria.NormalizeMetroURI));

            return this;
        }

        public NeighborhoodAreaQueryObject AddZoomLevel()
        {
            switch (this.Criteria.Zoom)
            {
                case 13:
                    this.And(x => x.LType == 1);
                    break;
                case 14:
                    this.And(x => (x.LType == 1 && !x.HasChild) || x.LType == 2);
                    break;
                case 15:
                    this.And(x => ((x.LType == 1 || x.LType == 2) && !x.HasChild) || x.LType == 3);
                    break;
            }

            return this;
        }
    }
}