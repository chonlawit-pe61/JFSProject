using System;
using System.Configuration;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace Megazy.StarterKit.Engine.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            //HttpContext.Current.Response.Headers.Remove("Server");
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string[] headers = { "Server" };

            if (!Response.HeadersWritten)
            {
                Response.AddOnSendingHeaders((c) =>
                {
                    if (c != null && c.Response != null && c.Response.Headers != null)
                    {
                        foreach (string header in headers)
                        {
                            if (c.Response.Headers[header] != null)
                            {
                                c.Response.Headers.Remove(header);
                            }
                        }
                    }
                });
            }

        }
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.CookieName = "hw";
        }

        private void Application_Error(object sender, EventArgs e)
        {
            string customError = ConfigurationManager.AppSettings["CustomError"];

            if (customError == "true")
            {

                Exception lastError = Server.GetLastError();
                Server.ClearError();

                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, lastError);

                int statusCode = 0;

                if (lastError.GetType() == typeof(HttpException))
                {
                    statusCode = ((HttpException)lastError).GetHttpCode();
                }
                else
                {
                    // Not an HTTP related error so this is a problem in our code, set status to
                    // 500 (internal server error)
                    statusCode = 500;
                }

                HttpContextWrapper contextWrapper = new HttpContextWrapper(this.Context);

                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "Index");
                routeData.Values.Add("statusCode", statusCode);
                routeData.Values.Add("exception", lastError);
                routeData.Values.Add("isAjaxRequet", contextWrapper.Request.IsAjaxRequest());

                IController controller = new ErrorController();

                RequestContext requestContext = new RequestContext(contextWrapper, routeData);

                controller.Execute(requestContext);
                Response.End();
            }
        }
        #region สำหรับแก้ไข Session กรณีเรียกผ่าน API
        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }
        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiConfig.UrlPrefixRelative);
        }
        #endregion

        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}
    }
}
