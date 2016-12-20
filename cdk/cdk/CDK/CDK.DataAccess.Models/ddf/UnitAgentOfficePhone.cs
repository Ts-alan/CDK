using Repository.Pattern.Ef6;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentOfficePhone : Entity
    {
        public long Id
        {
            get; set;
        }

        public long UnitAgentOfficeId
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

        public virtual UnitAgentOffice UnitAgentOffice
        {
            get; set;
        }
    }
}