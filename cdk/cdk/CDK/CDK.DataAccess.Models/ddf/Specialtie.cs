using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class Specialtie : Entity, IDdfMetadata
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

        public virtual System.Collections.Generic.ICollection<UnitAgent> UnitAgents
        {
            get; set;
        }

        public Specialtie()
        {
            UnitAgents = new System.Collections.Generic.HashSet<UnitAgent>();
        }
    }
}