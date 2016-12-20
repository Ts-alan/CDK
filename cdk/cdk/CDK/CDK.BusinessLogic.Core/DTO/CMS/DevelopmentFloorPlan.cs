namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class DevelopmentFloorPlan : BasePhotoModel, ISeoModel, ISequenceModel, IPhotoModel
    {
        public new long? Id
        {
            get; set;
        }

        public long DevelopmentId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public string Beds
        {
            get; set;
        }

        public string Baths
        {
            get; set;
        }

        public string PropertyTaxe
        {
            get; set;
        }

        public string InteriorSize
        {
            get; set;
        }

        public string OwnershipType
        {
            get; set;
        }

        public decimal? CondoMonthlyFees
        {
            get; set;
        }

        public string BalconeySize
        {
            get; set;
        }

        public int SequenceNumber
        {
            get; set;
        }

        public string PropertyTaxePeriod
        {
            get; set;
        }

        public string CondoFeesPeriod
        {
            get; set;
        }

        public string InteriorSizeType
        {
            get; set;
        }

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