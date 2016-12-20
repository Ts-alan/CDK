namespace CDK.DataAccess.Models.cdk
{
    // Development

    public class Development : BaseModel, ISeoModel
    {
        public long DeveloperId
        {
            get; set;
        } // DeveloperId

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

        public string PrimaryContactPhone
        {
            get; set;
        } // PrimaryContactPhone (length: 255)

        public string SecondaryContactName
        {
            get; set;
        } // SecondaryContactName (length: 255)

        public string SecondaryContactEmail
        {
            get; set;
        } // SecondaryContactEmail (length: 255)

        public string SecondaryContactPhone
        {
            get; set;
        } // SecondaryContactPhone (length: 255)

        public string ProjectWebsiteUrl
        {
            get; set;
        } // ProjectWebsiteUrl (length: 255)

        public string ProjectFacebookUrl
        {
            get; set;
        } // ProjectFacebookUrl (length: 255)

        public string ProjectTwiterUrl
        {
            get; set;
        } // ProjectTwiterUrl (length: 255)

        public string ProjectGooglePlusUrl
        {
            get; set;
        } // ProjectGooglePlusUrl (length: 255)

        public string SalesCenterPhoneNumber
        {
            get; set;
        } // SalesCenterPhoneNumber (length: 255)

        public string SalesCenterAddress
        {
            get; set;
        } // SalesCenterAddress (length: 255)

        public string SalesCenterPhone
        {
            get; set;
        } // SalesCenterPhone (length: 255)

        public string SalesCenterOpenHours
        {
            get; set;
        } // SalesCenterOpenHours

        public string ConstructuedYear
        {
            get; set;
        } // ConstructuedYear (length: 4)

        public bool? ForSale
        {
            get; set;
        } // ForSale

        public bool? ForRent
        {
            get; set;
        } // ForRent

        public string BuildingType
        {
            get; set;
        } // BuildingType (length: 255)

        public string Community
        {
            get; set;
        } // Community (length: 255)

        public decimal? PriceAveragePerSqrFeet
        {
            get; set;
        } // PriceAveragePerSqrFeet

        public int? TotalNumberOfUnits
        {
            get; set;
        } // TotalNumberOfUnits

        public int? TotalNumberOfStories
        {
            get; set;
        } // TotalNumberOfStories

        public string SalesCompany
        {
            get; set;
        } // SalesCompany (length: 255)

        public string MarketingCompany
        {
            get; set;
        } // MarketingCompany (length: 255)

        public string Architects
        {
            get; set;
        } // Architects (length: 255)

        public string InteriorDesigner
        {
            get; set;
        } // InteriorDesigner (length: 255)

        public string ProjectSummary
        {
            get; set;
        } // ProjectSummary

        public string ShortProjectSummary
        {
            get; set;
        } // ShortProjectSummary

        public string ProjectAmenities
        {
            get; set;
        } // ProjectAmenities (length: 255)

        public string CurrentIncentives
        {
            get; set;
        } // CurrentIncentives (length: 255)

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
        public virtual System.Collections.Generic.ICollection<DevelopmentFloorPlan> DevelopmentFloorPlans
        {
            get; set;
        } // DevelopmentFloorPlan.FK__Developme__Devel__2C88998B

        public virtual System.Collections.Generic.ICollection<DevelopmentPhoto> DevelopmentPhotos
        {
            get; set;
        } // DevelopmentPhoto.FK__Developme__Devel__2D7CBDC4

        public virtual System.Collections.Generic.ICollection<DevelopmentVideo> DevelopmentVideos
        {
            get; set;
        } // DevelopmentVideo.FK__Developme__Devel__2E70E1FD

        // Foreign keys
        public virtual Developer Developer
        {
            get; set;
        } // FK__Developme__Devel__2AA05119

        public virtual DevelopmentAddress DevelopmentAddress
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<DevelopmentAmenities> DevelopmentAmenities
        {
            get; set;
        }

        public Development()
        {
            DevelopmentFloorPlans = new System.Collections.Generic.HashSet<DevelopmentFloorPlan>();
            DevelopmentPhotos = new System.Collections.Generic.HashSet<DevelopmentPhoto>();
            DevelopmentVideos = new System.Collections.Generic.HashSet<DevelopmentVideo>();
            DevelopmentAmenities = new System.Collections.Generic.HashSet<DevelopmentAmenities>();
        }
    }
}