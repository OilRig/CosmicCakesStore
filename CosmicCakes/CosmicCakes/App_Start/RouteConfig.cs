using CosmicCakes.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace CosmicCakesWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GoHome",
                url: "home",
                defaults: new {controller = "Home", action = nameof(HomeController.Index) }
            );

            routes.MapRoute(
                name: "Prices",
                url: "prices",
                defaults: new { controller = "Home", action = nameof(HomeController.Prices) }
            );

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = nameof(HomeController.About) }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog",
                defaults: new { controller = "Home", action = nameof(HomeController.Blog) }
            );

            routes.MapRoute(
                name: "Inventory",
                url: "inventory",
                defaults: new { controller = "Home", action = nameof(HomeController.CakeParts) }
            );

            routes.MapRoute(
                name: "Cakes",
                url: "cakes",
                defaults: new { controller = "Cake", action = nameof(CakeController.Index) });

            routes.MapRoute(
               name: "CakeInfo",
               url: "cake/{id}",
               defaults: new { controller = "Cake", action = nameof(CakeController.CakeInfo), id = UrlParameter.Optional });
        }
    }
}
