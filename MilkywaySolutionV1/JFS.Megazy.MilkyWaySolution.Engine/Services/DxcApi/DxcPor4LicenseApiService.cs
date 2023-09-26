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
    // บริการค้นหาข้อมูล ข้อมูลใบอนุญาตป.4
    //Base URL: https://api.dxc.go.th/services/dxc-qm-moi-linkage-service/v2/api-docs

    public class DxcPor4LicenseApiService
    {
        private readonly HttpClient _httpClient;
        public DxcPor4LicenseApiService() : this(null) { }
        public DxcPor4LicenseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }
        public async Task<Por4LicenseResult> GetAsync(string accessToken, string cardID, DopaFilters filters)
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
            ///api/v2/moi-linkage/persons/{cardID}/moi-dopa-por4-licenses
            requestUrl.Append($"https://api.dxc.go.th/services/dxc-qm-moi-linkage-service/api/v2/moi-linkage/persons/{cardID}/moi-dopa-por4-licenses");
            //var components = ConvertCompenentFiltersToQuerystringParameter(filters);

            //if (!string.IsNullOrWhiteSpace(components))
            //{
            //    requestUrl.Append(components);
            //}
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Fix สำหรับแก้ไขปัญหา: The request was aborted: Could not create SSL/TLS secure channel.
            var httpClient = _httpClient ?? new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Add("X-User-Nin", filters.UserCardID);
            var response = await _httpClient.GetAsync(requestUrl.ToString())
                                           .ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync()
                                        .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage =
                    $"Failed to retrieve a Dxc token result. Status Code: {response.StatusCode}. Message: {content}";
                return new Por4LicenseResult
                {
                    Status = response.StatusCode.ToString(),
                    ErrorMessage = errorMessage,
                };
            }
            // Get content from json into rich object model.
            var resData = JsonConvert.DeserializeObject<Por4LicenseData>(content);
            return new Por4LicenseResult
            {
                Status = response.StatusCode.ToString(),
                Result = resData
            };
        }

        private static string ConvertCompenentFiltersToQuerystringParameter(DopaFilters filters)
        {
            var items = new Dictionary<string, string>();
            items.Add("X-User-Nin", filters.UserCardID.ToString());
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