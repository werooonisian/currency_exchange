using Currency_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency_Exchange
{
    public class CurrencyProcessor
    {
        public static async Task<Currency> LoadData()
        {
            string url = "http://api.nbp.pl/api/exchangerates/rates/a/usd/";

            using (HttpResponseMessage response = await ApiHelper.httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Currency currency = await response.Content.ReadAsAsync<Currency>();

                    return currency;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase); 
                }
            }
        }
    }
}
