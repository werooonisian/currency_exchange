using Currency_Exchange.Data; //????
using Currency_Exchange.Models;
using Currency_Exchange.ViewModels; //VM???????
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; //IDK ???
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency_Exchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICurrencyRepository _repository; //czy tu na pewno interface??????

        public HomeController(ICurrencyRepository repository)
        {
            _repository = repository;
        }




        [HttpPost("add_to_database")]
        public async Task PostDataToDatabase()
        {
            ApiHelper.InicializedClient(); // czy to tu???

            var currency = await CurrencyProcessor.LoadData();

            var _currency = new Currency
            {
               // Code = currency.Code,
               // Mid = currency.Mid,
               // EffectiveDate = currency.EffectiveDate
            };

            _repository.AddCurrencyToDatabase(_currency);
        }


        /*
        [HttpPost("addCurrency")]
        public IActionResult PostDataFirstTime()
        {
            var URL = $"https://api.nbp.pl/api/exchangerates/rates/a/usd/";
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(URL);
                //var currency = JsonSerializer.Deserialize(response);
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                var currency = JsonSerializer.Deserialize(json);


                
                //string json = response.Content.ReadAsStringAsync();

            }



           // _context.Currency.Add();

            return Ok();
        }
        */
        /*
        [HttpPost("https://api.nbp.pl/api/exchangerates/rates/a/usd/")]
        public IActionResult PostDataFirstTime(CurrencyVM currency)
        {
            var _currency = new Currency
            {
                code = currency.code,
                mid = currency.mid,
                effectiveDate = currency.effectiveDate
            };

            return Ok();
        }*/
    }
}
