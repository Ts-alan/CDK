using System.Web.Mvc;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity
{
    public class CdkEntityAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CdkEntity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CdkEntity_default",
                "CdkEntity/{controller}/{action}/{id}",
                new
                {
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}