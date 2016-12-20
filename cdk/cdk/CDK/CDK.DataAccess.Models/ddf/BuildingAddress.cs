using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class BuildingAddress : Entity
    {
        public long Id
        {
            get; set;
        }

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

        public string AddressType
        {
            get; set;
        }

        public string AdditionalStreetInfo
        {
            get; set;
        }

        public string DdfCommunityName
        {
            get; set;
        }

        public string Neighbourhood
        {
            get; set;
        }

        public string Subdivision
        {
            get; set;
        }

        public System.Data.Entity.Spatial.DbGeography PositionGeo
        {
            get; set;
        }

        public long? MetroAreaId
        {
            get; set;
        }

        public long? NeighborhoodAreaFirstLevelId
        {
            get; set;
        }

        public long? NeighborhoodAreaSecondLevelId
        {
            get; set;
        }

        public long? NeighborhoodAreaThirdLevelId
        {
            get; set;
        }

        public string FullAddress
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Building> Buildings
        {
            get; set;
        }

        public BuildingAddress()
        {
            Buildings = new System.Collections.Generic.HashSet<Building>();
        }
    }
}