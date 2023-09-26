using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.ERPData;
using Newtonsoft.Json;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.ERPApi
{
    public class BudgetApiService
    {
        private readonly string TOKEN = ConfigurationManager.AppSettings["ERPToken"].ToString();
        private readonly HttpClient _httpClient;

        public BudgetApiService() : this(null)
        {
        }

        public BudgetApiService(HttpClient httpClient)
        {
            //if (!string.IsNullOrWhiteSpace(apiKey))
            //{
            //    _apiKey = apiKey.Trim();
            //}
            _httpClient = httpClient ?? new HttpClient();
        }


        public async Task<BudgetDataResult> GetBudgetAsync()
        {
            var requestUrl = "https://jfportal.moj.go.th/finance_account/webservice/provide/BudgetCateList.php";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Token", TOKEN)

            });
            var httpClient = _httpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");// new AuthenticationHeaderValue( "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{DXCClientID}:{DXCClientSecret}")));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Token", TOKEN);//.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            var response = await httpClient.PostAsync(requestUrl, content).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a ERP token result. Status Code: {response.StatusCode}. Message: {result}";
                return new BudgetDataResult
                {
                     Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<BudgetData>(result);
            return new BudgetDataResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }
    }
}
