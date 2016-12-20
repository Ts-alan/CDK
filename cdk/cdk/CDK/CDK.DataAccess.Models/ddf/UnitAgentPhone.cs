using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentPhone : Entity
    {
        public long Id
        {
            get; set;
        }

        public long UnitAgentId
        {
            get; set;
        }

        public string ContactType
        {
            get; set;
        }

        public string PhoneType
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public virtual UnitAgent UnitAgent
        {
            get; set;
        }
    }
}