using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UpsaApi.DAL.Entities;

namespace UpsaApi.DAL.Utils
{
    public static class TokenHelper
    {
        private static HttpClient _httpClient;
        private const String User = "ivan_kushnir@epam.com";
        private const String Password = "K08v12a95I";

        static TokenHelper()
        {
            _httpClient = new HttpClient();
            var textBytes = Encoding.UTF8.GetBytes(User + ':' + Password);
            var base64Encoded = Convert.ToBase64String(textBytes);
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Basic " + base64Encoded);

        }

        public static async Task<TokenInfo> GetCurrentToken()
        {
            var requestTask = await _httpClient.PostAsync(
                @"https://upsa.epam.com/workload/rest/oauth/token",
                new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") }));

            var contentString = await requestTask.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(contentString);
            return new TokenInfo
            {
                Value = obj["value"].ToString(),
                FullName = obj["additionalInformation"]["userBean"]["pmcId"].ToString(),
                Id = obj["additionalInformation"]["userBean"]["pmcId"].ToString()
            };

        }
    }
}
