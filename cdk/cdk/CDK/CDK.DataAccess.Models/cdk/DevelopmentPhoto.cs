namespace CDK.DataAccess.Models.cdk
{
    // DevelopmentPhoto

    public class DevelopmentPhoto : BaseModel, ISeoModel, ISequenceModel, IPhotoModel
    {
        public long DevelopmentId
        {
            get; set;
        } // DevelopmentId

        public int SequenceNumber
        {
            get; set;
        } // SequenceNumber

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

        // Foreign keys
        public virtual Development Development
        {
            get; set;
        } // FK__Developme__Devel__2D7CBDC4
    }
}