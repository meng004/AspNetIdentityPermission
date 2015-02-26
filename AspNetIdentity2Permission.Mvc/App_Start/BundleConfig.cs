using System.Web;
using System.Web.Optimization;

namespace AspNetIdentity2Permission.Mvc
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //jquery-ui
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                 "~/Scripts/jquery-ui-{version}.js"
                ));
            //<!-- Ignite UI Required Combined CSS Files -->
            bundles.Add(new StyleBundle("~/IgniteUI/css").Include(
                "~/igniteui/css/themes/infragistics/infragistics.theme.css",
                "~/igniteui/css/structure/infragistics.css"
                ));
            //<!-- Ignite UI Required Combined JavaScript Files -->
            bundles.Add(new ScriptBundle("~/IgniteUI/js").Include(
                "~/igniteui/js/infragistics.core.js",
                "~/igniteui/js/infragistics.dv.js",
                "~/igniteui/js/infragistics.loader.js",
                "~/igniteui/js/infragistics.lob.js"
                ));
        }
    }
}
