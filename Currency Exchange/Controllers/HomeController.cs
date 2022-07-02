using Currency_Exchange.Data; //????
using Currency_Exchange.Models;
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
                Code = currency.Code,
                Rates = currency.Rates
            };

            _repository.AddCurrencyToDatabase(_currency);
        }
    }
}
