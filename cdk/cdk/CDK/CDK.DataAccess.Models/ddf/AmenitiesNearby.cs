using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class AmenitiesNearby : Entity, IDdfMetadata
    {
        public long Id
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string AlternateName
        {
            get; set;
        }

        public string ImgUrl
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<BuildingLand> BuildingLands
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Unit> Units
        {
            get; set;
        }

        public AmenitiesNearby()
        {
            Units = new System.Collections.Generic.HashSet<Unit>();
            BuildingLands = new System.Collections.Generic.HashSet<BuildingLand>();
        }
    }
}