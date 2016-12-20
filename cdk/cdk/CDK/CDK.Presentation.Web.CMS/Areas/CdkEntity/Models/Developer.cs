using System;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    // Developer

    public class Developer : BaseModel, ISeoModel
    {
        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Primary Contact Name")]
        [Required]
        [MaxLength(255)]
        public string PrimaryContactName
        {
            get; set;
        }

        [Display(Name = "Primary Contact Email")]
        [Required]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string PrimaryContactEmail
        {
            get; set;
        }

        [Display(Name = "Secondary Contact Name")]
        [MaxLength(255)]
        public string SecondaryContactName
        {
            get; set;
        }

        [Display(Name = "Secondary Contact Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string SecondaryContactEmail
        {
            get; set;
        }

        [Display(Name = "Address")]
        [MaxLength(255)]
        public string DeveloperAddress
        {
            get; set;
        }

        [Display(Name = "Description")]
        public string Description
        {
            get; set;
        } // Description

        [Display(Name = "Short Description")]
        public string ShortDescription
        {
            get; set;
        } // ShortDescription

        [Display(Name = "Logo")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(255)]
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