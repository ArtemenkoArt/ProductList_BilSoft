using System.Web.Mvc;
using System.Web.Routing;

namespace ProductList.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //paging Product
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Product", action = "Index" }
            );

            //paging ProductCategory
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "ProductCategory", action = "Index" }
            );

            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
