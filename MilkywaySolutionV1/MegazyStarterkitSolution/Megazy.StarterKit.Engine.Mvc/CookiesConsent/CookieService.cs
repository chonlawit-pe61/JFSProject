using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megazy.StarterKit.Engine.Mvc.CookiesConsent
{
    public class CookieService : ICookieService
    {
        public string Read(string cookieName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                return HttpContext.Current.Request.Cookies[cookieName].Value;
            }

            return string.Empty;
        }

        public void Store(string cookieName, string content)
        {
            //if (HttpContext.Current != null)
            //{
            //    HttpCookie cookie = new HttpCookie(cookieName, content)
            //    {
            //        Expires = DateTime.Now.AddYears(1)
            //    };
            //    HttpContext.Current.Request.Cookies.Add(cookie);
            //}
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
            {
                // no cookie found, create it
                //HttpContext.Current.Response.Cookies.Add(new HttpCookie(_membercart, memberNo));
                cookie = new HttpCookie(cookieName)
                {
                    Value = content
                };
            }
            else
            {
                // update the cookie values
                cookie.Value = content;
            }
            // update the expiration timestamp
            cookie.Expires = DateTime.UtcNow.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}