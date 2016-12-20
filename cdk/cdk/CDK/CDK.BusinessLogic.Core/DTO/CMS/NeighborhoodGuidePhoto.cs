namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class NeighborhoodGuidePhoto : BasePhotoModel, IPhotoModel, ISequenceModel, ISeoModel
    {
        public new long? Id
        {
            get; set;
        }

        public long NeighborhoodGuideId
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
    }
}