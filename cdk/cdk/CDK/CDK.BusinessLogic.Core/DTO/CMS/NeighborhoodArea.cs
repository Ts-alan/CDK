namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class NeighborhoodArea : BaseModel, ISeoModel
    {
        public long? MetroAreaId
        {
            get; set;
        }

        public MetroArea MetroArea
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public string CenterPointLat
        {
            get; set;
        }

        public string CenterPointLon
        {
            get; set;
        }

        public string CoordinatesAsText
        {
            get; set;
        }

        public string NeighborhoodAreaUri
        {
            get; set;
        }

        public string SeoCaption
        {
            get; set;
        }

        public string SeoDescription
        {
            get; set;
        }

        public string SeoKeywords
        {
            get; set;
        }

        public string SeoSlug
        {
            get; set;
        }

        public string SeoTitle
        {
            get; set;
        }

        public string SeoMetaDescription
        {
            get; set;
        }

        public string SeoURI
        {
            get; set;
        }
    }
}