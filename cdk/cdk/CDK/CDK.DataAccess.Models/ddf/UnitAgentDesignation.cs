using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentDesignation : Entity
    {
        public long Id
        {
            get; set;
        }

        public long UnitAgentId
        {
            get; set;
        }

        public string Designation
        {
            get; set;
        }

        public virtual UnitAgent UnitAgent
        {
            get; set;
        }
    }
}