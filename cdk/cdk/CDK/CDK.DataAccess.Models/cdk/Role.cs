using Microsoft.AspNet.Identity;

namespace CDK.DataAccess.Models.cdk
{
    public class Role : BaseModel, IRole<long>, IBaseModel
    {
        public string Name
        {
            get; set;
        }

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<User> Users
        {
            get; set;
        }

        public Role()
        {
            Users = new System.Collections.Generic.HashSet<User>();
        }
    }
}