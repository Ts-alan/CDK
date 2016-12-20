using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class DevelopmentFloorPlan : BasePhotoModel, ISeoModel
    {
        public long DevelopmentId
        {
            get; set;
        }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Type")]
        [MaxLength(255)]
        public string Type
        {
            get; set;
        }

        [Display(Name = "Beds")]
        [MaxLength(255)]
        public string Beds
        {
            get; set;
        }

        [Display(Name = "Baths")]
        [MaxLength(255)]
        public string Baths
        {
            get; set;
        }

        [Display(Name = "Property Taxe")]
        [MaxLength(255)]
        public string PropertyTaxe
        {
            get; set;
        }

        [Display(Name = "Interior Size")]
        [MaxLength(255)]
        public string InteriorSize
        {
            get; set;
        }

        [Display(Name = "Ownership Type")]
        [MaxLength(255)]
        public string OwnershipType
        {
            get; set;
        }

        [Display(Name = "Condo Monthly Fees")]
        [Range(0, double.MaxValue)]
        public decimal? CondoMonthlyFees
        {
            get; set;
        }

        [Display(Name = "Balconey Size")]
        [MaxLength(255)]
        public string BalconeySize
        {
            get; set;
        }

        [Display(Name = "Sequence Number")]
        [Range(0, int.MaxValue)]
        public int SequenceNumber
        {
            get; set;
        }


        [Display(Name = "Property Taxe Period")]
        [MaxLength(255)]
        public string PropertyTaxePeriod
        {
            get; set;
        }

        [Display(Name = "Condo Fees Period")]
        [MaxLength(255)]
        public string CondoFeesPeriod
        {
            get; set;
        }

        [Display(Name = "Interior Size Type")]
        [MaxLength(255)]
        public string InteriorSizeType
        {
            get; set;
        }

        [Display(Name = "Balconey Size Type")]
        [MaxLength(255)]
        public string BalconeySizeType
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