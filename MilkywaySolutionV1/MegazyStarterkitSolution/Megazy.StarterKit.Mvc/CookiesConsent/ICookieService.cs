using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megazy.StarterKit.Mvc.CookiesConsent
{
    public interface ICookieService
    {
        string Read(string cookieName);

        void Store(string cookieName, string content);
    }
}