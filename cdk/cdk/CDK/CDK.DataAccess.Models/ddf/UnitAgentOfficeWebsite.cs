using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentOfficeWebsite : Entity
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

        public string WebsiteType
        {
            get; set;
        }

        public string WebsiteUrl
        {
            get; set;
        }

        public virtual UnitAgentOffice UnitAgentOffice
        {
            get; set;
        }
    }
}