using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;
namespace Megazy.StarterKit.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("local", typeof(LocalConstraint));
            constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);
            // routes.MapMvcAttributeRoutes();

            /*โปรดระวัง!!!!! : เมื่อเปลี่ยน Route แล้ว Chrome จะยังจำ route เดิมต้องไปใช้ browser อื่นเพื่อ debug route 19 Feb 2021*/
            /* routes.MapRoute(
             name: "HomeCtrllocal", url: "{lang}/home/{acc}/{id}",
             defaults: new { controller = "Home", action = "Page", id = UrlParameter.Optional },
             namespaces: new[] { "HelloPhuket.Megazy.MilkyWaySolution.Controllers" },
             constraints: new { lang = new LocalConstraint(), acc = new ValuesConstraint("about|download|car|deal|contact|transport") });// constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
             routes.MapRoute(
                name: "HomeCtrl", url: "home/{acc}/{id}",
                defaults: new { controller = "Home", action = "Page", id = UrlParameter.Optional },
                namespaces: new[] { "HelloPhuket.Megazy.MilkyWaySolution.Controllers" },
                constraints: new { acc = new ValuesConstraint("about|download|car|deal|contact|transport") });// constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US

          routes.MapRoute(
              name: "announcementRoute",
              url: "{leftPath}/{announcementUrl}",
              defaults: new { controller = "Home", action = "Announces", announcementUrl = UrlParameter.Optional },
              constraints: new { leftPath = new ValuesConstraint(Tools.GetRouteValues("announcements")) }
          );*/

            //Language
            routes.MapRoute(
               name: "Local", url: "{lang}/{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "HelloPhuket.Megazy.MilkyWaySolution.Controllers" },
               constraints: new { lang = new LocalConstraint() });// constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US

            routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = "" }, new[] { "HelloPhuket.Megazy.MilkyWaySolution.Controllers" });
            routes.MapRoute("home-index", "home/index", new { controller = "Error", action = "NotFound" }, new[] { "HelloPhuket.Megazy.MilkyWaySolution.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
