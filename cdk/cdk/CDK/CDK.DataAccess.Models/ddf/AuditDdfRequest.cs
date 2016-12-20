using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class AuditDdfRequest : Entity
    {
        public long RequestId
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }

        public string Xml
        {
            get; set;
        }

        public System.DateTime? DdfLastUpdate
        {
            get; set;
        }
    }
}