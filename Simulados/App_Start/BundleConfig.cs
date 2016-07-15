using System.Web;
using System.Web.Optimization;

namespace Simulados
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/metro.min.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/metro.css",
                "~/Content/metro-icons.min.css",
                "~/Content/metro-colors.min.css",
                "~/Content/metro-responsive.min.css",
                "~/Content/metro-rtl.min.css",
                "~/Content/metro-schemes.min.css",
                "~/Content/site.css"));
        }
    }
}
