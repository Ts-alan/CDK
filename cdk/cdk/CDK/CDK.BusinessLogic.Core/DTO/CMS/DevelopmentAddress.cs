namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class DevelopmentAddress : BaseModel
    {
        public string StreetAddress
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string CountryState
        {
            get; set;
        }

        public string PostalCode
        {
            get; set;
        }

        public string Country
        {
            get; set;
        }

        public string Lon
        {
            get; set;
        }

        public string Lat
        {
            get; set;
        }

        public System.Data.Entity.Spatial.DbGeography PositionGeo
        {
            get; set;
        }

        public string StreetType
        {
            get; set;
        }

        public string AdditionalStreetInfo
        {
            get; set;
        }

        public string CommunityName
        {
            get; set;
        }

        public long? NeighborhoodAreaId
        {
            get;
            set;
        }
    }
}