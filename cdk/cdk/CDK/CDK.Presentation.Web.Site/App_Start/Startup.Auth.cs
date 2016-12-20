using Microsoft.Owin.Security.OAuth;
using Owin;

namespace CDK.Presentation.Web.Site
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions
        {
            get; private set;
        }

        public static string PublicClientId
        {
            get; private set;
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            BusinessLogic.Core.ConfigureAuth.Configure(app);

            PublicClientId = BusinessLogic.Core.ConfigureAuth.PublicClientId;
            OAuthOptions = BusinessLogic.Core.ConfigureAuth.OAuthOptions;
        }
    }
}