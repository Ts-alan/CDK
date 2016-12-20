namespace CDK.DataAccess.Models.cdk
{
    // NeighborhoodGuidePhoto

    public class NeighborhoodGuidePhoto : BaseModel, ISeoModel, ISequenceModel, IPhotoModel
    {
        public long NeighborhoodGuideId
        {
            get; set;
        } // NeighborhoodGuideId

        // Foreign keys
        public virtual NeighborhoodGuide NeighborhoodGuide
        {
            get; set;
        } // FK__Neighborh__Neigh__314D4EA8

        public int SequenceNumber
        {
            get; set;
        }

        public string ThumbnailUri
        {
            get; set;
        }

        public string LargeUri
        {
            get; set;
        }

        public string SmallUri
        {
            get; set;
        }

        public string AltText
        {
            get; set;
        }

        public string PhotoName
        {
            get; set;
        }

        public string PhotoType
        {
            get; set;
        }

        public string PhotoDescription
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