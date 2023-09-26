using System.Web;
using System.Web.Optimization;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/assets/js/scripts-init/web-common.js",
                      "~/Scripts//jquery.validationEngine.js",
                      "~/Scripts/jquery.validationEngine-th.js",
                      "~/assets/js/scripts-init/handlebars-helper.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"
                      , "~/Content/fontawesome-all.css"
                      , "~/Content/validationEngine.jquery.css"
                      , "~/assets/css/skins/grey.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862

            BundleTable.EnableOptimizations = false;
//#if (DEBUG)
//            #else
//            BundleTable.EnableOptimizations = true;
//#endif
        }
    }
}
