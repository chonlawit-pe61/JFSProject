using Microsoft.Web.Http.Routing;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Megazy.StarterKit.Engine.Mvc
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };
            #region สำหรับแก้ไข Session กรณีเรียกผ่าน API
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: UrlPrefix + "/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
            #endregion
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning();
        }

    }
}
