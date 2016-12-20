using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitParkingSpace : Entity
    {
        public long Id
        {
            get; set;
        }

        public long UnitId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Spaces
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }
    }
}