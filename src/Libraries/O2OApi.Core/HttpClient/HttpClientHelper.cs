using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace O2OApi.Core.HttpClient
{
    public  class HttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
