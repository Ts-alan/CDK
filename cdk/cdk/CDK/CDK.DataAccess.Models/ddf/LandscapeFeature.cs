using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class LandscapeFeature : Entity, IDdfMetadata
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

        public LandscapeFeature()
        {
            BuildingLands = new System.Collections.Generic.HashSet<BuildingLand>();
        }
    }
}