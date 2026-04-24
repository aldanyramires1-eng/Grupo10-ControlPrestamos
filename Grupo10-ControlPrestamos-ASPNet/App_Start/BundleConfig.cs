using System.Web.Optimization;
using System.Web.UI;

namespace Grupo10_ControlPrestamos_ASPNet
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJQueryScriptManager();

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.7.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.bundle.js"));
        }

        private static void RegisterJQueryScriptManager()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.7.0.min.js",
                    DebugPath = "~/Scripts/jquery-3.7.0.js"
                });
        }
    }
}
