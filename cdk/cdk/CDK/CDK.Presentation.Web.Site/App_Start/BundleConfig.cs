using System.Threading;
using System.Web;
using System.Web.Optimization;

namespace CDK.Presentation.Web.Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif


#if DEBUG
            bundles.Add(new StyleBundle("~/Content/styles").Include(
            "~/Content/Site.css"));

            bundles.Add(new Bundle("~/bundles/angular").Include("~/App/js/angular.js"));

            bundles.Add(new Bundle("~/bundles/app").Include("~/App/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/App/js/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/App/js/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/App/js/bootstrap.js"));
#else
            bundles.Add(new StyleBundle("~/Content/styles").Include(
            "~/Content/Site.min.css"));

            bundles.Add(new Bundle("~/bundles/angular").Include("~/App/js/angular.min.js"));

            bundles.Add(new Bundle("~/bundles/app").Include("~/App/js/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/App/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/App/js/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/App/js/bootstrap.min.js"));
#endif

        }
    }
}
