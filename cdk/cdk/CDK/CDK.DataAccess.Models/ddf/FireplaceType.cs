using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class FireplaceType : Entity, IDdfMetadata
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

        public virtual System.Collections.Generic.ICollection<Building> Buildings
        {
            get; set;
        }

        public FireplaceType()
        {
            Buildings = new System.Collections.Generic.HashSet<Building>();
        }
    }
}