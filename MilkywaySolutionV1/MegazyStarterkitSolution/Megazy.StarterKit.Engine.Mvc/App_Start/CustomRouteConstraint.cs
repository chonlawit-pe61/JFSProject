using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Megazy.StarterKit.Engine.Mvc
{
    public class LocalConstraint : IRouteConstraint
    {
        public static string[] Lng = new[] { "en", "zh" };
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // return true;
            if (values[parameterName] == null)
                return false;

            //get the category passed in to the route
            var para = values[parameterName].ToString();
            //now we check our categories, and see if it exists
            return Lng.Any(x => x == para.ToLower());
            //return httpContext.Request.IsLocal;
        }
    }

    public class ValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;
        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}