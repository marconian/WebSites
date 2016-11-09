using System.Web;
using System.Web.Optimization;

namespace StalRondo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/node_modules/jquery/dist/jquery.js",
                        "~/node_modules/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/node_modules/jquery-validation/dist/jquery.validate.js",
                        "~/node_modules/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/node_modules/modernizr/bin/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/node_modules/tether/dist/js/tether.js",
                      "~/node_modules/bootstrap/dist/js/bootstrap.js",
                      "~/node_modules/respond.js/dest/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/cropper").Include(
                      "~/node_modules/cropperjs/dist/cropper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/node_modules/tether/dist/css/tether.css",
                      "~/node_modules/bootstrap/dist/css/bootstrap.css",
                      "~/node_modules/font-awesome/css/font-awesome.css",
                      "~/node_modules/cropperjs/dist/cropper.css",
                      "~/Content/site.css"));
        }
    }
}
