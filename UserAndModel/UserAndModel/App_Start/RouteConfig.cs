using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserAndModel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "new",
                url: "newEntry",
                defaults: new { controller = "Home", action = "newentry", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "add",
                url: "add",
                defaults: new { controller = "Home", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "update",
             url: "update/{cin}",
             defaults: new { controller = "Home", action = "Update", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "edit",
                url: "edit/{cin}",
                defaults: new { controller = "Home", action = "Edit", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "delete",
                url: "delete/{cin}",
                defaults: new { controller = "Home", action = "Delete", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
