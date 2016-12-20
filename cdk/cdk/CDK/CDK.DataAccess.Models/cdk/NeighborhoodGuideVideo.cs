namespace CDK.DataAccess.Models.cdk
{
    // NeighborhoodGuideVideo

    public class NeighborhoodGuideVideo : BaseModel, ISeoModel, IVideoModel, ISequenceModel
    {
        public long NeighborhoodGuideId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public string Uri
        {
            get; set;
        }

        public string AltText
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public int SequenceNumber
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

        // Foreign keys
        public virtual NeighborhoodGuide NeighborhoodGuide
        {
            get; set;
        }
    }
}