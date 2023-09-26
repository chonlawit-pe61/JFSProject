using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public class DxcTokenApiService : IDxcTokenApiService
    {
        private readonly string DXCGetDataUrl = ConfigurationManager.AppSettings["DXCGetDataUrl"].ToString();
        private readonly string DXCGetAccessTokenUrl = ConfigurationManager.AppSettings["DXCGetAccessTokenUrl"].ToString();
        private readonly string DXCClientID = ConfigurationManager.AppSettings["DXCClientID"].ToString();
        private readonly string DXCClientSecret = ConfigurationManager.AppSettings["DXCClientSecret"].ToString();
        private readonly string DXCRedirecURL = ConfigurationManager.AppSettings["DXCRedirecURL"].ToString();
        //private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public DxcTokenApiService() : this(null)
        {
        }

        public DxcTokenApiService(HttpClient httpClient)
        {
            //if (!string.IsNullOrWhiteSpace(apiKey))
            //{
            //    _apiKey = apiKey.Trim();
            //}
            _httpClient = httpClient ?? new HttpClient();
        }


        public async Task<DxcDataResult> TokenAsync(string code, string code_verifier)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }
            string client_id_client_secret = CommonEncrypt.ComputeBase64(DXCClientID + ":" + DXCClientSecret);
            var requestUrl = DXCGetAccessTokenUrl;
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", DXCClientID),
                new KeyValuePair<string, string>("client_secret", DXCClientSecret),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code_verifier", code_verifier),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", DXCRedirecURL),

            });
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var httpClient = _httpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", client_id_client_secret);// new AuthenticationHeaderValue( "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{DXCClientID}:{DXCClientSecret}")));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var response = await httpClient.PostAsync(requestUrl, content).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a Dxc token result. Status Code: {response.StatusCode}. Message: {result}";
                //DalBase.ExceptEngine.KeepLogOnly(CSystemsAsync.ProcessID, new Exception(result));
                return new DxcDataResult
                {
                    Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
             var resData = JsonConvert.DeserializeObject<DxcData>(result);
            //DalBase.ExceptEngine.KeepLogOnly(CSystemsAsync.ProcessID, new Exception(result));
            return new DxcDataResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }
        public async Task<DxcDataResult> RefreshTokenAsync(string refresh_token)
        {
            if (string.IsNullOrWhiteSpace(refresh_token))
            {
                throw new ArgumentNullException(nameof(refresh_token));
            }
            int processID = CSystemsAsync.ProcessID;
            DxcDataResult res = new DxcDataResult();
            try
            {
                string client_id_client_secret = CommonEncrypt.ComputeBase64(DXCClientID + ":" + DXCClientSecret);
                var requestUrl = DXCGetAccessTokenUrl;
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", DXCClientID),
                new KeyValuePair<string, string>("client_secret", DXCClientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refresh_token),
                new KeyValuePair<string, string>("redirect_uri", DXCRedirecURL),

            });
                var httpClient = _httpClient ?? new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", client_id_client_secret);// new AuthenticationHeaderValue( "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{DXCClientID}:{DXCClientSecret}")));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var response = await httpClient.PostAsync(requestUrl, content).ConfigureAwait(false);
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage =
                        $"Failed to retrieve a Dxc refresh token result. Status Code: {response.StatusCode}. Message: {result}";
                    DalBase.ExceptEngine.KeepLogOnly(processID, new Exception(result));
                    return new DxcDataResult
                    {
                        Status = response.StatusCode.ToString(),
                        ErrorMessage = errorMessage,
                    };
                }
                // Get content from json into rich object model.
                var resData = JsonConvert.DeserializeObject<DxcData>(result);
                res.Status = response.StatusCode.ToString();
                res.Result = resData;
                //DalBase.ExceptEngine.KeepLogOnly(processID, new Exception(result));

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.KeepLogOnly(processID, ex);
            }
            return res;
        }

        //public async Task<string> TokenAsync(string code, string code_verifier)
        //{

        /*var client = new RestClient("https://sso.dxc.go.th/auth/realms/DXC/protocol/openid-connect/token");
          client.Timeout = -1;
          var request = new RestRequest(Method.POST);
          request.AddHeader("Authorization", "Basic amZvLW5ld2pmczo5YjdjMzJhZi04NGRmLTQ0OWEtYmYxNS1kNTQ5ZDc0OGZkYjE=");
          request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
          request.AddParameter("client_id", "jfo-newjfs");
          request.AddParameter("client_secret", "9b7c32af-84df-449a-bf15-d549d748fdb1");
          request.AddParameter("code_verifier", "8d1fc993383745310b8933fa9215d9e1e87f9f61d194622f0b4eab5d");
          request.AddParameter("grant_type", "authorization_code");
          request.AddParameter("code", "b9fdd7c5-7e4f-40f2-a8c1-fe9c79b4f398.742d0bf4-0a8b-40cc-a866-e89ee2fa27ff.fd4c881f-1c55-4749-9b5b-8fcfea93e48f");
          request.AddParameter("redirect_uri", "https://localhost:44339/dxc");
          IRestResponse response = client.Execute(request);
        */
        // Console.WriteLine(response.Content);
        //IRestResponse response = client.Execute(request);
        //Console.WriteLine(response.Content);




        //string client_id_client_secret = CommonEncrypt.ComputeBase64(DXCClientID + ":" + DXCClientSecret);
        //var client = new RestClient(requestUrl);
        //client.Timeout = -1;
        //var request = new RestRequest(Method.POST);
        //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //request.AddHeader("Authorization", $"Basic {client_id_client_secret}");
        //request.AddParameter("client_id", DXCClientID);
        //request.AddParameter("client_secret", DXCClientSecret);
        //request.AddParameter("code_verifier", code_verifier);
        //request.AddParameter("grant_type", "authorization_code");
        //request.AddParameter("code", code); //Authorization Code
        //request.AddParameter("redirect_uri", DXCRedirecURL); //Authorization Code
        //  var cancellationTokenSource = new CancellationTokenSource();
        //  //var restResponse =
        //  //    await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
        //  Task<IRestResponse> t = client.ExecuteAsync(request, cancellationTokenSource.Token);// client.Execute(request);
        //  t.Wait();
        //  //Console.WriteLine(response.Content);
        //  var res = await t;//.Content;
        //var resspon  =  res.Content;

        //    throw new NotImplementedException();
        //}



    }
}
