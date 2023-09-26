﻿using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
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
    //ค้นหาข้อมูลด้วยข้อมูลตัวอย่าง
    //Base URL: https://api.dxc.go.th/services/dxc-qm-djop-juvenile-offender-service/v2/api-docs

    public class DxcJuvenilOffenderApiService : IDxcJuvenilOffenderApiService
    {
        private readonly HttpClient _httpClient;
        public DxcJuvenilOffenderApiService() : this(null) { }
        public DxcJuvenilOffenderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<JuvenilOffenderResult> JuvenilOffenderAsync(string accessToken, string cardID, JuvenilOffenderFilters filters)
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
            requestUrl.Append($"https://api.dxc.go.th/services/dxc-qm-djop-juvenile-offender-service/api/v2/djop/juvenile-offenders?citizenCardNumber={cardID}&");
            var components = ConvertCompenentFiltersToQuerystringParameter(filters);

            if (!string.IsNullOrWhiteSpace(components))
            {
                requestUrl.Append(components);
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var httpClient = _httpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync(requestUrl.ToString())
                                           .ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a Dxc token result. Status Code: {response.StatusCode}. Message: {content}";
                return new JuvenilOffenderResult
                {
                    Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<JuvenilOffenderData>(content);
            return new JuvenilOffenderResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }
   
        private static string ConvertCompenentFiltersToQuerystringParameter(JuvenilOffenderFilters filters)
        {
            var items = new Dictionary<string, string>();
            items.Add("direction", filters.SortDirection);
            if (!string.IsNullOrWhiteSpace(filters.Firstname))
            {
                items.Add("firstname", filters.Firstname.ToString());
            }
            items.Add("size", filters.Size.ToString());
            if (!items.Any())
            {
                return string.Empty;
            }
            var queryString = new StringBuilder();
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
