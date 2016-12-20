using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class Business : Entity
    {
        public long Id
        {
            get; set;
        }

        public long? UnitId
        {
            get; set;
        }

        public string BusinessType
        {
            get; set;
        }

        public string BusinessSubType
        {
            get; set;
        }

        public string EstablishedDate
        {
            get; set;
        }

        public string Franchise
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string OperatingSince
        {
            get; set;
        }

        public virtual Unit Unit
        {
            get; set;
        }
    }
}