using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDK.Presentation.Web.Site.Startup))]
namespace CDK.Presentation.Web.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
