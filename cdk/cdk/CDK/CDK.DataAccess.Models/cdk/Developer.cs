using System;

namespace CDK.DataAccess.Models.cdk
{
    // Developer

    public class Developer : BaseModel, ISeoModel
    {
        public string Name
        {
            get; set;
        } // Name (length: 255)

        public string PrimaryContactName
        {
            get; set;
        } // PrimaryContactName (length: 255)

        public string PrimaryContactEmail
        {
            get; set;
        } // PrimaryContactEmail (length: 255)

        public string SecondaryContactName
        {
            get; set;
        } // SecondaryContactName (length: 255)

        public string SecondaryContactEmail
        {
            get; set;
        } // SecondaryContactEmail (length: 255)

        public string DeveloperAddress
        {
            get; set;
        }    //DeveloperAddress

        public string Description
        {
            get; set;
        } // Description

        public string ShortDescription
        {
            get; set;
        } // ShortDescription

        public string LogoUri
        {
            get; set;
        } // LogoUri (length: 255)

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

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Development> Developments
        {
            get; set;
        }

        public Developer()
        {
            Developments = new System.Collections.Generic.HashSet<Development>();
        }
    }
}