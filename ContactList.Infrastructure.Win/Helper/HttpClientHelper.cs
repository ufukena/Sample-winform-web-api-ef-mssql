using ContactList.Infrastructure.Win.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ContactList.Infrastructure.Win.Helper
{
    public static class HttpClientHelper
    {
        public static HttpClient GetClient()
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(HttpConfig.BaseUri);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return _httpClient;                      
        }

    }

}
