using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    //https://api.dxc.go.th/services/dxc-qm-rlpd-requestor-service/api/am/api/rlpd/complainants/nins/{nin}

    public class DxcRLPDApiService : IDxcRLPDApiService
    {
        private readonly HttpClient _httpClient;
        public DxcRLPDApiService() : this(null) { }
        public DxcRLPDApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<DxcDataResult> ComplainantsAsync(string accessToken, string cardID, RLPDFilters filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }
            if (string.IsNullOrWhiteSpace(cardID))
            {
                throw new ArgumentNullException(nameof(cardID));
            }
            var requestUrl = new StringBuilder();
            requestUrl.Append($"https://api.dxc.go.th/services/dxc-qm-rlpd-requestor-service/api/am/api/rlpd/complainants/nins/{cardID}/?");
            var components = ConvertCompenentFiltersToQuerystringParameter(filters);
            if (!string.IsNullOrWhiteSpace(components))
            {
                requestUrl.Append(components);
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.

            var httpClient = _httpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
           // httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var response = await _httpClient.GetAsync(requestUrl.ToString())
                                           .ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);
                      
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a Dxc token result. Status Code: {response.StatusCode}. Message: {content}";
                return new DxcDataResult
                {
                    Status = response.StatusCode.ToString(),
                    StatusCode =(int)response.StatusCode,
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<DxcData>(content);
            return new DxcDataResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }

        public Task<DxcDataResult> RefreshTokenAsync(string refresh_token)
        {
            throw new NotImplementedException();
        }

        private static string ConvertCompenentFiltersToQuerystringParameter(RLPDFilters filters)
        {
            var items = new Dictionary<string, string>();
            items.Add("userNin", filters.UserCardID);
            items.Add("page", filters.Page.ToString());
            items.Add("size", filters.Size.ToString());
            if (!items.Any())
            {
                return string.Empty;
            }
            var queryString = new StringBuilder();
            //foreach (var item in items)
            //{
            //    if (queryString.Length > 0)
            //    {
            //        queryString.Append("|");
            //    }
            //    queryString.AppendFormat("{0}:{1}", item.Key, item.Value);
            //}
            foreach (var item in items)
            {
                if (queryString.Length > 0)
                {
                    queryString.Append("&");
                }

                queryString.AppendFormat("{0}={1}", item.Key, item.Value);
            }
            return queryString.ToString();
        }
    }
}
