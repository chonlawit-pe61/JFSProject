using System;
using System.Web;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class SiteSession
    {
        private static string _user = "CURRENTMEMBER";
        private static string _session_auth = "SESSION_AUTH";
        private static string _user_agent = "CURR_AGENT";

        #region MEMBER
        public static void SetUser(CurrentUser user)
        {
            HttpContext.Current.Session[_user] = user;
        }
        public static CurrentUser GetCurrentUser()
        {
            CurrentUser ret = new CurrentUser();

            if (HttpContext.Current.Session[_user] != null)
            {
                ret = (CurrentUser)HttpContext.Current.Session[_user];
            }

            return ret;
        }
        public static void ResetUser()
        {
            SiteCookies.ResetAuthCookie();

            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();

            HttpContext.Current.Session[_user] = null;
            HttpContext.Current.Session[_session_auth] = null;
            HttpContext.Current.Session[_user_agent] = null;
        }
        #endregion

        #region AUTHEN
        public static void SetClientAuthen()
        {
            string authStr = Guid.NewGuid().ToString();
            HttpContext.Current.Session[_session_auth] = authStr;
            SiteCookies.SetAuthCookie(authStr);

            string ip = HttpContext.Current.Request.UserHostAddress;
            ip = new Utility().GetAuthIP(ip);
            HttpContext.Current.Session[_user_agent] = HttpContext.Current.Request.UserAgent + " " + ip;

        }

        public static string GetAuth()
        {
            string ret = string.Empty;
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session[_session_auth] != null)
                {
                    ret = (string)HttpContext.Current.Session[_session_auth];
                }
                else
                {
                    DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, new Exception("SiteSeseeion.GetAuth(),_session_auth.L78 NULL"));
                }
            }
            else
            {
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, new Exception("SiteSeseeion.GetAuth().L83 NULL"));
            }

            return ret;
        }

        public static string GetUserAgent()
        {
            string ret = string.Empty;
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session[_user_agent] != null)
                {
                    ret = (string)HttpContext.Current.Session[_user_agent];
                }
            }
            return ret;
        }
        #endregion
    }
}