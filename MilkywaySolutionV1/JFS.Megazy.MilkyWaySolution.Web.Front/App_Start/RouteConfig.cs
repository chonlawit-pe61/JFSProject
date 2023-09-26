using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //Language
            routes.MapRoute(
               name: "en", url: "en/{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "JFS.Megazy.MilkyWaySolution.Web.Front.Controllers" });

            routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = "" }, new[] { "JFS.Megazy.MilkyWaySolution.Web.Front.Controllers" });
            routes.MapRoute("home-index", "home/index", new { controller = "Error", action = "NotFound" }, new[] { "JFS.Megazy.MilkyWaySolution.Web.Front.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "JFS.Megazy.MilkyWaySolution.Web.Front.Controllers" }
            );
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
