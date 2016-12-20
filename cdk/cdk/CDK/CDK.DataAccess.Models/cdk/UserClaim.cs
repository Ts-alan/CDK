namespace CDK.DataAccess.Models.cdk
{
    public class UserClaim : BaseModel, IBaseModel
    {
        public long UserId
        {
            get; set;
        }

        public string ClaimType
        {
            get; set;
        }

        public string ClaimValue
        {
            get; set;
        }

        // Foreign keys
        public virtual User User
        {
            get; set;
        }
    }
}