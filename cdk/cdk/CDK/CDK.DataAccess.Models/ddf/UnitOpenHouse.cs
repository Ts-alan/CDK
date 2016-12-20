using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitOpenHouse : Entity
    {
        public long Id
        {
            get; set;
        }

        public long UnitId
        {
            get; set;
        }

        public string StartDateTime
        {
            get; set;
        }

        public string EndDateTime
        {
            get; set;
        }

        public string Comments
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }
    }
}