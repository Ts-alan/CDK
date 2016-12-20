using System;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    // DevelopmentPhoto

    public class DevelopmentPhoto : BasePhotoModel, ISeoModel
    {       

        public long DevelopmentId
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