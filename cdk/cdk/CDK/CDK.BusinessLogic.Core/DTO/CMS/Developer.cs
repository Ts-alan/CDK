using System;

namespace CDK.BusinessLogic.Core.DTO.CMS
{
    // Developer

    public class Developer : BaseModel, ISeoModel
    {
        public string Name
        {
            get; set;
        }

        public string PrimaryContactName
        {
            get; set;
        }

        public string PrimaryContactEmail
        {
            get; set;
        }

        public string SecondaryContactName
        {
            get; set;
        }

        public string SecondaryContactEmail
        {
            get; set;
        }

        public string DeveloperAddress
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public string ShortDescription
        {
            get; set;
        }

        public string LogoUri
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