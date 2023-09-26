using Banish.Treasure.Megazy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class SiteCookies
    {
        private static string _auth = "gjx";

        #region Authen
        public static void SetAuthCookie(string authToken)
        {
            HttpCookie cookieAuth = HttpContext.Current.Request.Cookies[_auth];
            if (cookieAuth == null)
            {
                cookieAuth = new HttpCookie(_auth)
                {
                    Value = authToken,
                    HttpOnly = true
                };
                //cookieAuth.Secure = true;
            }
            else
            {
                HttpContext.Current.Response.Cookies.Remove(_auth);
                cookieAuth = new HttpCookie(_auth)
                {
                    Value = authToken,
                    HttpOnly = true
                };
            }
            cookieAuth.Expires = DateTime.UtcNow.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookieAuth);
        }
        public static string GetAuthCookie()
        {
            string ret = string.Empty;
            if (HttpContext.Current.Request.Cookies[_auth] != null)
            {
                ret = HttpContext.Current.Request.Cookies[_auth].Value;
            }

            return ret;
        }
        public static void ResetAuthCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[_auth];
            if (cookie != null)
            {
                cookie.Expires = DateTime.UtcNow.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

    }
}