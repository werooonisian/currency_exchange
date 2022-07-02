using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers; //////
using System.Threading.Tasks;

namespace Currency_Exchange
{
    public static class ApiHelper
    {
        public static HttpClient httpClient { get; set; }

        public static void InicializedClient()
        {
            httpClient = new HttpClient();
           // httpClient.BaseAddress = new Uri("http://api.nbp.pl/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
