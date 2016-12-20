using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class Development : BaseModel, IVideoContainerModel, IPhotoContainerModel, ISeoModel
    {
        [Display(Name = "Developer")]
        [Required]
        public long? DeveloperId
        {
            get; set;
        }


        public List<long> DevelopmentAmenitiesIds
        {
            get; set;
        }

        public List<DevelopmentAmenities> DevelopmentAmenities
        {
            get; set;
        }

        public List<DevelopmentFloorPlan> DevelopmentFloorPlans
        {
            get; set;
        }

        public List<DevelopmentVideo> DevelopmentVideos
        {
            get; set;
        }

        public List<DevelopmentPhoto> DevelopmentPhotos
        {
            get; set;
        }

        public Developer Developer
        {
            get; set;
        }

        public DevelopmentAddress DevelopmentAddress
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

        [Display(Name = "Primary Contact Phone")]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string PrimaryContactPhone
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

        [Display(Name = "Secondary Contact Phone")]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string SecondaryContactPhone
        {
            get; set;
        }

        [Display(Name = "Website Url")]
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string ProjectWebsiteUrl
        {
            get; set;
        }

        [Display(Name = "Facebook Url")]
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string ProjectFacebookUrl
        {
            get; set;
        }

        [Display(Name = "Twitter Url")]
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string ProjectTwiterUrl
        {
            get; set;
        }

        [Display(Name = "Google+ Url")]
        [MaxLength(255)]
        [DataType(DataType.Url)]
        public string ProjectGooglePlusUrl
        {
            get; set;
        }

        [Display(Name = "Sales Center Phone Number")]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string SalesCenterPhoneNumber
        {
            get; set;
        }

        [Display(Name = "Sales Center Address")]
        [MaxLength(255)]
        public string SalesCenterAddress
        {
            get; set;
        }

        [Display(Name = "Sales Center Phone")]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string SalesCenterPhone
        {
            get; set;
        }

        [Display(Name = "Sales Center Open Hours")]
        public string SalesCenterOpenHours
        {
            get; set;
        }

        [Display(Name = "Constructued Year")]
        [MaxLength(4)]
        public string ConstructuedYear
        {
            get; set;
        }

        [Display(Name = "For Sale")]
        public bool ForSale
        {
            get; set;
        }

        [Display(Name = "For Rent")]
        public bool ForRent
        {
            get; set;
        }

        [Display(Name = "Building Type")]
        [MaxLength(255)]
        public string BuildingType
        {
            get; set;
        }

        [Display(Name = "Community")]
        [MaxLength(255)]
        public string Community
        {
            get; set;
        }

        [Display(Name = "Price Average Per Sqr. Feet")]
        [Range(0, double.MaxValue)]
        public decimal PriceAveragePerSqrFeet
        {
            get; set;
        }

        [Display(Name = "Total Number Of Units")]
        [Range(0, int.MaxValue)]
        public int TotalNumberOfUnits
        {
            get; set;
        }

        [Display(Name = "Total Number Of Stories")]
        [Range(0, int.MaxValue)]
        public int TotalNumberOfStories
        {
            get; set;
        }

        [Display(Name = "Sales Company")]
        [MaxLength(255)]
        public string SalesCompany
        {
            get; set;
        }

        [Display(Name = "Marketing Company")]
        [MaxLength(255)]
        public string MarketingCompany
        {
            get; set;
        }

        [Display(Name = "Architects")]
        [MaxLength(255)]
        public string Architects
        {
            get; set;
        }

        [Display(Name = "Interior Designer")]
        [MaxLength(255)]
        public string InteriorDesigner
        {
            get; set;
        }

        [Display(Name = "Project Summary")]
        public string ProjectSummary
        {
            get; set;
        }

        [Display(Name = "Short Project Summary")]
        public string ShortProjectSummary
        {
            get; set;
        }

        [Display(Name = "Project Amenities")]
        [MaxLength(255)]
        public string ProjectAmenities
        {
            get; set;
        }

        [Display(Name = "Current Incentives")]
        [MaxLength(255)]
        public string CurrentIncentives
        {
            get; set;
        }

        [Display(Name = "Logo Uri")]
        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string LogoUri
        {
            get; set;
        }

        //For UI
        [AllowHtml]
        public string FloorsPlanJSON
        {
            get; set;
        }

        [AllowHtml]
        public string PhotoJSON
        {
            get; set;
        }


        public string PhotoStorageUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["blobUrl"];
            }
        }

        public string DevelopmentFloorsPlanJSON()
        {
            return JsonConvert.SerializeObject((this.DevelopmentFloorPlans ?? Enumerable.Empty<DevelopmentFloorPlan>()).OrderBy(x => x.SequenceNumber));
        }

        public string VideosJSON
        {
            get; set;
        }

        public string VideoListJSON()
        {
            return JsonConvert.SerializeObject((this.DevelopmentVideos ?? Enumerable.Empty<DevelopmentVideo>()).OrderBy(x => x.SequenceNumber));
        }

        public string PhotoListJSON()
        {
            return JsonConvert.SerializeObject((this.DevelopmentPhotos ?? Enumerable.Empty<DevelopmentPhoto>()).OrderBy(x => x.SequenceNumber));
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