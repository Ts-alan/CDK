using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentContact : Entity
    {
        public long Id
        {
            get; set;
        }

        public string ContactType
        {
            get; set;
        }

        public string AgentType
        {
            get; set;
        }

        public string TextValue
        {
            get; set;
        }

        public System.DateTime LastUpdate
        {
            get; set;
        }

        public long? UnitAgentId
        {
            get; set;
        }

        public virtual UnitAgent UnitAgent
        {
            get; set;
        }
    }
}