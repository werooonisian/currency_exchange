using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; //?????
using System.Threading.Tasks;

namespace Currency_Exchange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

      /*  public static async void GetCurrency()
        {
            string baseUrl = "http://api.nbp.pl/api/exchangerates/rates/a/usd/";

            try
            {
                using(HttpClient client = new HttpClient())
                {

                }
            }

            catch(Exception exception)
            {

            }
        } */
    }
}