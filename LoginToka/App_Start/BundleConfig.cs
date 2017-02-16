using System.Web;
using System.Web.Optimization;

namespace LoginToka
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/dataTables.bootstrap.js",
                      //"~/Scripts/DataTables/responsive.bootstrap.js",
                      "~/Scripts/DataTables/buttons.bootstrap.js",
                      "~/Scripts/DataTables/dataTables.buttons.js",
                      "~/Scripts/DataTables/buttons.flash.js",
                      "~/Scripts/DataTables/jszip.min.js",
                      "~/Scripts/DataTables/pdfmake.min.js",
                      "~/Scripts/DataTables/vfs_fonts.js",
                      "~/Scripts/DataTables/buttons.html5.js",
                      "~/Scripts/DataTables/buttons.print.js"
                    //,
                    //"~/Scripts/DataTables/buttons.print.js"
                    ));

            // CSS /////////////////////////////////////////////////////////////
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/bootstrap-theme.css",

                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/DataTables/css/responsive.bootstrap.css",
                      "~/Content/DataTables/css/dataTables.material.css",                      
                      "~/Content/DataTables/css/buttons.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
