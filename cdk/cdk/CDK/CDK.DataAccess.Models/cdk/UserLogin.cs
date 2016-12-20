using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.cdk
{
    public class UserLogin : Entity
    {
        public string LoginProvider
        {
            get; set;
        }

        public string ProviderKey
        {
            get; set;
        }

        public long UserId
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