using JFS.Megazy.MilkyWaySolution.Web.Front.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class ErrorUtility
    {
        public static void RedirectPage(string title, int statusCode)
        {
            HttpContextWrapper contextWrapper = new HttpContextWrapper(HttpContext.Current);

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Show");
            routeData.Values.Add("title", title);
            routeData.Values.Add("statusCode", statusCode);

            IController controller = new ErrorController();

            RequestContext requestContext = new RequestContext(contextWrapper, routeData);

            controller.Execute(requestContext);
        }
    }
}