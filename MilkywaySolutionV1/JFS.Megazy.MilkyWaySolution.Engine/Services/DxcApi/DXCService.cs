using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class DXCService
    {

        //field set 
        private static readonly string DXCGetDataUrl = ConfigurationManager.AppSettings["DXCGetDataUrl"].ToString();
        private static readonly string DXCGetAccessTokenUrl = ConfigurationManager.AppSettings["DXCGetAccessTokenUrl"].ToString();
        private static readonly string DXCClientID = ConfigurationManager.AppSettings["DXCClientID"].ToString();
        private static readonly string DXCClientSecret = ConfigurationManager.AppSettings["DXCClientSecret"].ToString();
        private static readonly string DXCRedirecURL = ConfigurationManager.AppSettings["DXCRedirecURL"].ToString();

        public static ResponseResult GetDxcVeify(int userID)
        {
            ResponseResult res = new ResponseResult();
            DXCAccessTokenCollection_Base obj = new DXCAccessTokenCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(userID);
            obj.Dispose();
            if (row != null && !string.IsNullOrEmpty(row.AccessToken))
            {
                res.Status = true;
                res.Data = new DXCAccessTokenData
                {
                    AccessToken = row.AccessToken,
                    AuthorizationCode = row.AuthorizationCode,
                    CodeChallenge = row.CodeChallenge,
                    CodeVerifier = row.CodeVerifier,
                };
            }
            else
            {
                //CommonEncrypt.ComputeCodeVerifier();
                string CodeVerifier = CommonEncrypt.ComputeCodeVerifier();
                string CodeChallenge = CommonEncrypt.MakeCodeChallenge(CodeVerifier);
                obj = new DXCAccessTokenCollection_Base(CSystems.ProcessID);
                obj.DeleteByPrimaryKey(userID);
                obj.Dispose();

                obj = new DXCAccessTokenCollection_Base(CSystems.ProcessID);
                obj.InsertOnlyPlainText(new DXCAccessTokenRow
                {
                    CodeChallenge = CodeChallenge,
                    CodeVerifier = CodeVerifier,
                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID),
                    UserID = userID,

                });
                obj.Dispose();
                res.Data = CodeChallenge;//code_challenge
                res.Status = false;
            }

            return res;
        }
        public static string AccessToken(int userID)
        {

            string res = string.Empty;
            DXCAccessTokenCollection_Base obj = new DXCAccessTokenCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(userID);
            obj.Dispose();
            if (row != null)
            {
                //ใช้งานได้
                string OAuth2AccessTokenURL = "https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/token";

                string client_id_client_secret = CommonEncrypt.ComputeBase64urlencode(DXCClientID + ":" + DXCClientSecret);
                var client = new RestClient(OAuth2AccessTokenURL);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", $"Basic {client_id_client_secret}");
                request.AddParameter("client_id", DXCClientID);
                request.AddParameter("client_secret", DXCClientSecret);
                request.AddParameter("code_verifier", "0fdf7dd1e0ac60677f6142ec0f8d31e11e800800ad0e5e6dd9324d09");
                request.AddParameter("grant_type", "authorization_code");
                request.AddParameter("code", "63106ea6-6e0c-490c-9653-1ed80afc0f84.742d0bf4-0a8b-40cc-a866-e89ee2fa27ff.fd4c881f-1c55-4749-9b5b-8fcfea93e48f"); //Authorization Code
                request.AddParameter("redirect_uri", DXCRedirecURL); //Authorization Code
                IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                res = response.Content;
            }
            return res;
        }


        /// <summary>
        ///  Access Token
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="auth"></param>
        /// <returns></returns>
        //public static void AuthorizationCode()
        //{
        //    var client = new RestClient("https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth");
        //    client.Timeout = -1;
        //    var code_challenge = CommonEncrypt.ComputeBase64urlencodeSha256Hash("999999");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("code_challenge", code_challenge);
        //    request.AddParameter("code_challenge_method", "S256");
        //    request.AddParameter("response_type", "code");
        //    request.AddParameter("client_id", "jfo-newjfs");
        //    request.AddParameter("scope", "offline_access dxc-data email profile nin");
        //    request.AddParameter("redirect_uri", DXCRedirecURL);
        //    IRestResponse response = client.Execute(request);
        //    //Console.WriteLine(response.Content);
        //    string res = response.Content;
        //    // return res;
        //}
        public static void AuthorizationCode2()
        {
            var code_challenge = CommonEncrypt.MakeCodeChallenge("990");

            //UriBuilder builder = new UriBuilder("https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth");
            //builder.Query = "name='abc'&password='cde'";
            string uri = string.Format("https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth?code_challenge={0}&code_challenge_method={1}&response_type={2}&client_id={3}&redirect_uri={4}&scope={5}", code_challenge, "S256", "code", "jfo-newjfs", DXCRedirecURL, "offline_access dxc-data email profile nin");

            //Create a query
            HttpClient client = new HttpClient();
            var result = client.GetAsync(uri).Result;

            //using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}


            // Task.Run(() => MainAsync());
        }
        static async Task MainAsync()
        {
            var code_challenge = CommonEncrypt.MakeCodeChallenge("990");
            using (var client = new HttpClient())
            {
                string uri = string.Format("https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/auth?code_challenge={0}&code_challenge_method={1}&response_type={2}&client_id={3}&redirect_uri={4}&scope={5}", code_challenge, "S256", "code", "jfo-newjfs", DXCRedirecURL, "offline_access dxc-data email profile nin");
                client.BaseAddress = new Uri(uri);
                //    var content = new FormUrlEncodedContent(new[]
                //    {
                //    new KeyValuePair<string, string>("code_challenge",code_challenge)
                //    ,new KeyValuePair<string, string>("code_challenge_method", "S256")
                //    ,new KeyValuePair<string, string>("response_type", "code")
                //    ,new KeyValuePair<string, string>("client_id", "jfo-newjfs")
                // ,new KeyValuePair<string, string>("scope", "offline_access dxc-data email profile nin")
                //    ,new KeyValuePair<string, string>("redirect_uri", DXCRedirecURL)
                //});
                var result = await client.GetAsync("/auth/realms/DXC/protocol/openid-connect/auth");
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        private static string RefreshToken(string refreshToken)
        {

            string res = string.Empty;
            string client_id_client_secret = CommonEncrypt.ComputeBase64urlencode(DXCClientID + ":" + DXCClientSecret);
            var client = new RestClient(DXCGetAccessTokenUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {client_id_client_secret}");
            request.AddParameter("client_id", DXCClientID);
            request.AddParameter("client_secret", DXCClientSecret);
            request.AddParameter("refresh_token", refreshToken);
            request.AddParameter("grant_type", "refresh_token");//FIX
            request.AddParameter("redirect_uri", DXCRedirecURL); //Authorization Code
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            res = response.Content;

            return res;
        }


        /// <summary>
        ///  Get Personal Data
        /// </summary>
        /// <param name="cardNorequest"></param>
        /// <param name="cardNoOfficer"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetPersonalData(string cardNorequest, string cardNoOfficer, string dataType)
        {

            string res = string.Empty;
            DXCAccessTokenCollection_Base dXCAccessToken = new DXCAccessTokenCollection_Base(CSystems.ProcessID);

            try
            {

                DXCAccessTokenRow accessTokenRow = dXCAccessToken.GetByPrimaryKey(1);
                //dXCAccessToken.Dispose();
                if (accessTokenRow != null)
                {

                    var jsonPersonStr = SetPersonalData(cardNorequest, cardNoOfficer, accessTokenRow.AccessToken, dataType);
                    JObject jsonPerson = JObject.Parse(jsonPersonStr.ToString());
                    var checkErrorPerson = jsonPerson.ContainsKey("error");

                    if (checkErrorPerson)
                    {

                        //Unauthorized
                        if (jsonPerson["status"].Value<int>() == 401)
                        {

                            var refreshTokenData = RefreshToken(accessTokenRow.RefreshToken);
                            JObject newToken = JObject.Parse(refreshTokenData.ToString());

                            //"error": "invalid_grant",
                            //"error_description": "Refresh token expired"
                            var checkErrorRefreshToken = newToken.ContainsKey("error");

                            if (checkErrorRefreshToken)
                            {
                                //newToken = JObject.Parse(AccessToken().ToString());
                            }

                            if (!newToken.ContainsKey("error"))
                            {
                                //update token
                                DalBase dal = new DalBase();
                                accessTokenRow.UserID = 1;
                                accessTokenRow.AccessToken = newToken["access_token"].Value<string>();
                                accessTokenRow.ExpiresIn = newToken["expires_in"].Value<int>();
                                accessTokenRow.RefreshExpiresIn = newToken["refresh_expires_in"].Value<int>();
                                accessTokenRow.RefreshToken = newToken["refresh_token"].Value<string>();
                                //accessTokenRow.TokenType = newToken["token_type"].Value<string>();
                                //accessTokenRow.SessionState = newToken["session_state"].Value<string>();
                                //accessTokenRow.Scope = newToken["scope"].Value<string>();
                                accessTokenRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                                dXCAccessToken.UpdateOnlyPlainText(accessTokenRow);
                            }

                            //get  Personal Data
                            jsonPersonStr = SetPersonalData(cardNorequest, cardNoOfficer, accessTokenRow.AccessToken, dataType);
                        }
                    }

                    res = jsonPersonStr;
                }
            }
            catch (Exception ex)
            {

                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            finally
            {

                dXCAccessToken.Dispose();
            }
            return res;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardNorequest"></param>
        /// <param name="cardNoOfficer"></param>
        /// <param name="accessToken"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private static string SetPersonalData(string cardNorequest, string cardNoOfficer, string accessToken, string dataType)
        {

            string res = string.Empty;
            string stringQuery = $"{DXCGetDataUrl}/{cardNorequest}/{dataType}";
            var client = new RestClient(stringQuery);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-User-Nin", cardNoOfficer);
            request.AddHeader("Authorization", $"bearer {accessToken}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            res = response.Content;
            return res;
        }



        public enum DataTypePerson
        {
            [Description("mhdhs-new-born-babies")]
            P1,
            [Description("moac-fisheries-illegal-fishing-cases")]
            P2,
            [Description("moi-dol-land-and-condominium-titles")]
            P3,
            [Description("moi-dopa-addresses")]
            P4,
            [Description("moi-dopa-aliens")]
            P5,
            [Description("moi-dopa-birth-certificates")]
            P6,
            [Description("moi-dopa-border-passes")]
            P7,
            [Description("moi-dopa-death-certificates")]
            P8,
            [Description("moi-dopa-divorce-certificates")]
            P9,
            [Description("moi-dopa-education-backgroundes")]
            P10,
            [Description("moi-dopa-marriage-certificates")]
            P11,
            [Description("moi-dopa-passports")]
            P12,
            [Description("moi-dopa-person-face-photos")]
            P13,
            [Description("moi-dopa-persons")]
            P14,
        }




    }
}