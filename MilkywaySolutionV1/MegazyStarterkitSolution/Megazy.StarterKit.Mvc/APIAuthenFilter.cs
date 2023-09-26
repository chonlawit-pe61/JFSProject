using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Megazy.StarterKit.Mvc
{
    public class APIAuthenFilter : AuthorizationFilterAttribute
    {
        //set
        //Username = "webapiservice";
        //Password = "x#4578YG";
        //d2ViYXBpc2VydmljZTp4IzQ1NzhZRw==


        //set header
        //Authorization : BASIC  d2ViYXBpc2VydmljZTp4IzQ1NzhZRw==
        //send data from body
        private const string Username = "webapiservice";
        private const string Password = "x#4578YG";
        private const string Realm = "JFS";
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);

                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                //Get the authentication token from the request header
                string authenticationToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = string.Empty;
                string password = string.Empty;
                if (usernamePasswordArray.Length > 0)
                {
                    username = usernamePasswordArray[0].Trim();
                    password = usernamePasswordArray.Length > 1 ? usernamePasswordArray[1].Trim() : "";
                }

                //login check  username and password
                if (UserValidate(username, password))
                {
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

        //check  user Validate
        public static bool UserValidate(string username, string password)
        {
            bool status = false;
            if (username == Username && password == Password)
            {
                status = true;
            }
            return status;
        }
    }
}