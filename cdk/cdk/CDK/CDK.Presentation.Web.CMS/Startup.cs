using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDK.Presentation.Web.CMS.Startup))]

namespace CDK.Presentation.Web.CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}