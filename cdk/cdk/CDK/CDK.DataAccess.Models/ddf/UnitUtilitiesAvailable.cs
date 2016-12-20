using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitUtilitiesAvailable : Entity
    {
        public long UnitUtilitiesAvailableId
        {
            get; set;
        }

        public long UnitId
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }
    }
}