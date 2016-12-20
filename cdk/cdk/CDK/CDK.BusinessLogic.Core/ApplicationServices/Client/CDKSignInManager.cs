using CDK.DataAccess.Models.cdk;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client
{
    public class CDKSignInManager : SignInManager<User, long>
    {
        public CDKSignInManager(CDKUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return this.GenerateUserIdentityAsync(user, (CDKUserManager)UserManager);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, CDKUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public static CDKSignInManager Create(IdentityFactoryOptions<CDKSignInManager> options, IOwinContext context)
        {
            return new CDKSignInManager(context.GetUserManager<CDKUserManager>(), context.Authentication);
        }
    }
}