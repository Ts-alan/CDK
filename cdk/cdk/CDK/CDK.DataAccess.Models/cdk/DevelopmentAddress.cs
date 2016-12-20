namespace CDK.DataAccess.Models.cdk
{
    // DevelopmentAddress

    public class DevelopmentAddress : BaseModel
    {
        //public long DevelopmentId
        //{
        //    get; set;
        //}

        public long? NeighborhoodAreaId
        {
            get; set;
        }

        public string StreetAddress
        {
            get; set;
        } // StreetAddress (length: 255)

        public string City
        {
            get; set;
        } // City (length: 255)

        public string CountryState
        {
            get; set;
        } // CountryState (length: 255)

        public string PostalCode
        {
            get; set;
        } // PostalCode (length: 255)

        public string Country
        {
            get; set;
        } // Country (length: 255)

        public string Lon
        {
            get; set;
        } // Lon (length: 255)

        public string Lat
        {
            get; set;
        } // Lat (length: 255)

        public System.Data.Entity.Spatial.DbGeography PositionGeo
        {
            get; set;
        } // PositionGeo

        public string StreetType
        {
            get; set;
        } // StreetType (length: 255)

        public string AdditionalStreetInfo
        {
            get; set;
        } // AdditionalStreetInfo (length: 255)

        public string CommunityName
        {
            get; set;
        } // CommunityName (length: 255)

        // Reverse navigation
        public virtual Development Development
        {
            get; set;
        }

        public virtual NeighborhoodArea NeighborhoodArea
        {
            get; set;
        }

        public DevelopmentAddress()
        {
        }
    }
}