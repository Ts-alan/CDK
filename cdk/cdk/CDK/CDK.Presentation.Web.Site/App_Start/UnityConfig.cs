using CDK.BusinessLogic.Core;
using CDK.Presentation.Web.Site.Controllers.API;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Practices.Unity;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace CDK.Presentation.Web.Site
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = (new UnityFactory()).Container;

            container.RegisterType<ITextEncoder, Base64UrlTextEncoder>();
            container.RegisterType<IDataSerializer<AuthenticationTicket>, TicketSerializer>();
            container.RegisterInstance(new DpapiDataProtectionProvider().Create("ASP.NET Identity"));
            container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}