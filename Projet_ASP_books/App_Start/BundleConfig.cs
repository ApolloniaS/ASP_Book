using System.Web;
using System.Web.Optimization;

namespace Projet_ASP_books
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            //// prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/custo-css").Include(
                      "~/css/linearicons.css",
                      "~/css/font-awesome.min.css",
                      "~/css/bootstrap.css",
                      "~/css/magnific-popup.css",
                      "~/css/nice-select.css",
                      "~/css/animate.min.css",
                      "~/css/owl.carousel.css",
                      "~/css/main.css"));

            bundles.Add(new ScriptBundle("~/bundles/custo-js").Include(
                      "~/js/vendor/bootstrap.min.js",
                      "~/js/vendor/jquery-2.2.4.min.js",
                      "~/js/easing.min.js",
                      "~/js/hoverIntent.js",
                      "~/js/superfish.min.js",
                      "~/js/jquery.ajaxchimp.min.js",
                      "~/js/jquery.magnific-popup.min.js",
                      "~/js/owl.carousel.min.js",
                      "~/js/jquery.sticky.js",
                      "~/js/jquery.nice-select.min.js",
                      "~/js/parallax.min.js",
                      "~/js/waypoints.min.js",
                      "~/js/jquery.counterup.min.js",
                      "~/js/mail-script.js",
                      "~/js/main.js"));
        }
    }
}
