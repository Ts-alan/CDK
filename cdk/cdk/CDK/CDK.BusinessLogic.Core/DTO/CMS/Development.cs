using System.Collections.Generic;

namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class Development : BaseModel, ISeoModel, IPhotoContainer
    {
        public long DeveloperId
        {
            get; set;
        }

        public List<long> DevelopmentAmenitiesIds
        {
            get; set;
        }

        public List<DevelopmentFloorPlan> DevelopmentFloorPlans
        {
            get; set;
        }

        public List<DevelopmentAmenities> DevelopmentAmenities
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

        public string PrimaryContactPhone
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

        public string SecondaryContactPhone
        {
            get; set;
        }

        public string ProjectWebsiteUrl
        {
            get; set;
        }

        public string ProjectFacebookUrl
        {
            get; set;
        }

        public string ProjectTwiterUrl
        {
            get; set;
        }

        public string ProjectGooglePlusUrl
        {
            get; set;
        }

        public string SalesCenterPhoneNumber
        {
            get; set;
        }

        public string SalesCenterAddress
        {
            get; set;
        }

        public string SalesCenterPhone
        {
            get; set;
        }

        public string SalesCenterOpenHours
        {
            get; set;
        }

        public string ConstructuedYear
        {
            get; set;
        }

        public bool? ForSale
        {
            get; set;
        }

        public bool? ForRent
        {
            get; set;
        }

        public string BuildingType
        {
            get; set;
        }

        public string Community
        {
            get; set;
        }

        public decimal? PriceAveragePerSqrFeet
        {
            get; set;
        }

        public int? TotalNumberOfUnits
        {
            get; set;
        }

        public int? TotalNumberOfStories
        {
            get; set;
        }

        public string SalesCompany
        {
            get; set;
        }

        public string MarketingCompany
        {
            get; set;
        }

        public string Architects
        {
            get; set;
        }

        public string InteriorDesigner
        {
            get; set;
        }

        public string ProjectSummary
        {
            get; set;
        }

        public string ShortProjectSummary
        {
            get; set;
        }

        public string ProjectAmenities
        {
            get; set;
        }

        public string CurrentIncentives
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