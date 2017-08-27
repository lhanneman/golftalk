using System.Web.Optimization;

namespace GolfTalk
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                  "~/Scripts/jquery-3.1.1.min.js",
                  "~/Scripts/bootstrap.min.js",
                  "~/Scripts/jquery.signalR-2.2.2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css"));
        }
    }
}
