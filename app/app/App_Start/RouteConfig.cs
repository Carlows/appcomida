using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace app
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //exclude template folder from routing
            routes.IgnoreRoute("ViewsAngular/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "App", action = "Index", id = UrlParameter.Optional} ,
                constraints: new { controller = "App|Registros" }
            );

            routes.MapRoute(
                "NotFound",
                "{*url}",
                new { controller = "App", action = "Index" }
            );
        }
    }
}
