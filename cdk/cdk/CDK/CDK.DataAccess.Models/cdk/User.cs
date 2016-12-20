using Microsoft.AspNet.Identity;

namespace CDK.DataAccess.Models.cdk
{
    public class User : BaseModel, IUser<long>, IBaseModel
    {
        public string Email
        {
            get; set;
        }

        public bool EmailConfirmed
        {
            get; set;
        }

        public string PasswordHash
        {
            get; set;
        }

        public string SecurityStamp
        {
            get; set;
        }

        public string PhoneNumber
        {
            get; set;
        }

        public bool PhoneNumberConfirmed
        {
            get; set;
        }

        public bool TwoFactorEnabled
        {
            get; set;
        }

        public System.DateTime? LockoutEndDateUtc
        {
            get; set;
        }

        public bool LockoutEnabled
        {
            get; set;
        }

        public int AccessFailedCount
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string LastName
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Role> Roles
        {
            get; set;
        } // Many to many mapping

        public virtual System.Collections.Generic.ICollection<UserClaim> UserClaims
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UserLogin> UserLogins
        {
            get; set;
        } // Many to many mapping
        

        public User()
        {
            UserClaims = new System.Collections.Generic.HashSet<UserClaim>();
            UserLogins = new System.Collections.Generic.HashSet<UserLogin>();
            Roles = new System.Collections.Generic.HashSet<Role>();
        }
    }
}