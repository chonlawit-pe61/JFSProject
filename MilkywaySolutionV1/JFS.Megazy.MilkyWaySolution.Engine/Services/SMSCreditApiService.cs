using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public class SMSCreditApiService
    {
        private readonly string API_Key = "0b5a112e0c5f9d5d4e39f062389b8c57";
        private readonly string API_Secret = "8ae9125e6b72569da79da8f2ba2aa164";
        private readonly string _serviceEndPoint = "https://api-v2.thaibulksms.com/credit";
        private readonly HttpClient _httpClient;

        public SMSCreditApiService() : this(null) { }
        public SMSCreditApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<RemainingCreditDataResult> GETCreditAsync()
        {
        
            var httpClient = _httpClient ?? new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var authenticationString = $"{API_Key}:{API_Secret}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // httpClient.DefaultRequestHeaders.Add("Token", TOKEN);//.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(_serviceEndPoint).ConfigureAwait(true);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<ErrorContent>(result);
                var errorMessage =
                    $"เกิดข้อผิดพลาด: {errorData.error.code}.Message: {errorData.error.description}";
                return new RemainingCreditDataResult
                {
                    Status = errorData.error.code.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<RemainingCreditContent>(result);
            return new RemainingCreditDataResult
            {
                Status = "0",
                Result = resData
            };
        }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
  


}