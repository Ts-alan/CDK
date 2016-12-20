namespace CDK.DataAccess.Models.cdk
{
    // DevelopmentFloorPlan

    public class DevelopmentFloorPlan : BaseModel, ISeoModel, ISequenceModel, IPhotoModel
    {
        public long DevelopmentId
        {
            get; set;
        } // DevelopmentId

        public string Name
        {
            get; set;
        } // Name (length: 255)

        public string Type
        {
            get; set;
        } // Type (length: 255)

        public string Beds
        {
            get; set;
        } // Beds (length: 255)

        public string Baths
        {
            get; set;
        } // Baths (length: 255)

        public string PropertyTaxe
        {
            get; set;
        } // PropertyTaxe (length: 255)

        public string InteriorSize
        {
            get; set;
        } // InteriorSize (length: 255)

        public string OwnershipType
        {
            get; set;
        } // OwnershipType (length: 255)

        public decimal? CondoMonthlyFees
        {
            get; set;
        } // CondoMonthlyFees

        public string BalconeySize
        {
            get; set;
        } // BalconeySize (length: 255)

        public int SequenceNumber
        {
            get; set;
        } // SequenceNumber

        public string PropertyTaxePeriod
        {
            get; set;
        } // PropertyTaxePeriod (length: 255)

        public string CondoFeesPeriod
        {
            get; set;
        } // CondoFeesPeriod (length: 255)

        public string InteriorSizeType
        {
            get; set;
        } // InteriorSizeType (length: 255)

        public string BalconeySizeType
        {
            get; set;
        } // BalconeySizeType (length: 255)

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
        }
    }
}