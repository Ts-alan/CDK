using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class DevelopmentAddress : BaseModel
    {
        [Display(Name = "Neighborhood Area")]
        public long? NeighborhoodAreaId
        {
            get; set;
        }

        [Display(Name = "Street Address")]
        [Required]
        [MaxLength(255)]
        public string StreetAddress
        {
            get; set;
        }

        [Display(Name = "City")]
        [Required]
        [MaxLength(255)]
        public string City
        {
            get; set;
        }

        [Display(Name = "Country State")]
        [Required]
        [MaxLength(255)]
        public string CountryState
        {
            get; set;
        }

        [Display(Name = "Postal Code")]
        [Required]
        [MaxLength(255)]
        public string PostalCode
        {
            get; set;
        }

        [Display(Name = "Country")]
        [Required]
        [MaxLength(255)]
        public string Country
        {
            get; set;
        }

        [Display(Name = "Street Type")]
        [Required]
        [MaxLength(255)]
        public string StreetType
        {
            get; set;
        }

        [Display(Name = "Additional Street Info")]
        [Required]
        [MaxLength(255)]
        public string AdditionalStreetInfo
        {
            get; set;
        }

        [Display(Name = "Community Name")]
        [Required]
        [MaxLength(255)]
        public string CommunityName
        {
            get; set;
        }
    }
}