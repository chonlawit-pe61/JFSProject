using JFS.Megazy.MilkyWaySolution.Engine;
using System.Web.Mvc;
using System.Web.Routing;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class WebViewAuthorizeFilter : AuthorizeAttribute
    {
        //private readonly bool _changepwd;
        //public WebViewAuthorizeFilter(bool changepwd = false)
        //{
        //    _changepwd = changepwd;
        //}
        public override void OnAuthorization(AuthorizationContext ctx)
        {
            
            CurrentUser currentUser = SiteSession.GetCurrentUser();
            string authCookie = SiteCookies.GetAuthCookie();
            string ip = ctx.HttpContext.Request.UserHostAddress;
            ip = new Utility().GetAuthIP(ip);
            string currentUA = ctx.HttpContext.Request.UserAgent + " " + ip;
            //if (_changepwd)
            //{
            //    if (currentUser != null)
            //        currentUser.IsLogin = _changepwd;
            //}
            if (currentUser == null || !currentUser.IsLogin)
            {
                var url = ctx.HttpContext.Request.Url.PathAndQuery;
                ctx.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "home", action = "login", repath = url }));
            }
            //else if (!SiteSession.GetAuth().Equals(authCookie) || !SiteSession.GetUserAgent().Equals(currentUA))
            //{

            //    var url = ctx.HttpContext.Request.Url.PathAndQuery;
            //    ctx.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "home", action = "WebSignIn", repath = url }));
            //}

        }
    }
  
}