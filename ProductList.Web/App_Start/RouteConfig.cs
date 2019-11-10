using System.Web.Mvc;
using System.Web.Routing;

namespace ProductList.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //
            routes.MapRoute(
                null,
                "",
                new { controller = "Product", action = "Index", page = 1}
            );

            //
            routes.MapRoute(
                name: null,
                url: "{controller}/Page{page}",
                defaults: new { controller = "{controller}", action = "Index" },
                constraints: new { page = @"\d+" }
            );

            //
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
