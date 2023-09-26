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
    public class SMSApiService
    {
        private readonly string API_Key =  "0b5a112e0c5f9d5d4e39f062389b8c57";
        private readonly string API_Secret = "8ae9125e6b72569da79da8f2ba2aa164";
        private readonly string _serviceEndPoint = "https://api-v2.thaibulksms.com/sms";
        private readonly HttpClient _httpClient;

        public SMSApiService() : this(null) { }
        public SMSApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<SMSDataResult> SendSMSAsync(string telephone, string message, string sendername = "", string message1 = null)
        {
            if (string.IsNullOrWhiteSpace(sendername))
                sendername = "Smart-SMS";
            var content = new FormUrlEncodedContent(new[]
          {
                new KeyValuePair<string, string>("msisdn",telephone),//เบอร์โทร เช่น 0812345678, 0919874563
                new KeyValuePair<string, string>("message",message),
                new KeyValuePair<string, string>("force","corporate"),//credit type(standard/corporate)
                new KeyValuePair<string, string>("sender",sendername),//sender
               new KeyValuePair<string, string>("shorten_url","true")
            });
            var httpClient = _httpClient ?? new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var authenticationString = $"{API_Key}:{API_Secret}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // httpClient.DefaultRequestHeaders.Add("Token", TOKEN);//.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(_serviceEndPoint, content).ConfigureAwait(true);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            if (!response.IsSuccessStatusCode)
            {
                var errorData = JsonConvert.DeserializeObject<ErrorContent>(result);
                var errorMessage =
                    $"เกิดข้อผิดพลาด: {errorData.error.code}.Message: {errorData.error.description}";
                return new SMSDataResult
                {
                    Status = errorData.error.code.ToString(),
                    ErrorMessage = errorMessage,
                };
            }          
         
            try
            {
                var resData = JsonConvert.DeserializeObject<SMSContent>(result);
                return new SMSDataResult
                {
                    Status = "0",
                    Result = resData
                };
            }
            catch 
            {
                DalBase.ExceptEngine.KeepLogOnly(CSystems.ProcessID, new Exception(result));
            }
            return new SMSDataResult
            {
                Status = "Error",
                ErrorMessage = "ไม่สามารถแปลงค่า Json ได้",
            };

        }
    
    
    }
    public class Error
    {
        public int code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ErrorContent
    {
        public Error error { get; set; }
    }

}