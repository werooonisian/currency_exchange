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
        private readonly ICurrencyRepository _repository; 

        public HomeController(ICurrencyRepository repository)
        {
            _repository = repository;
        }




        [HttpPost("add_to_database")]
        public async Task PostDataToDatabase()
        {
            ApiHelper.InicializedClient(); 

            var currency = await CurrencyProcessor.LoadData();

            var _currency = new Currency
            {
                Code = currency.Code,
                Rates = currency.Rates
            };

            _repository.AddCurrencyToDatabase(_currency);
        }

        [HttpPut("update_database")]
        public async Task UpdateDateInDatabase()
        {
            Rate rate = _repository.GetDateFromDatabase();

            if(DateTime.Now.ToString("yyyy-MM-dd") != rate.EffectiveDate)
            {

                ApiHelper.InicializedClient();

                var currency = await CurrencyProcessor.LoadData();

                Currency currency_from_db =  _repository.GetByCode(currency.Code);
                Rate rate_from_db = _repository.GetByCurrencyId(currency_from_db.Id); //maybe zmienić na rate????

                rate_from_db.EffectiveDate = currency.Rates.FirstOrDefault().EffectiveDate;
                rate_from_db.Mid = currency.Rates.FirstOrDefault().Mid;

                _repository.UpdateCurrencyRate(rate_from_db);
            }
        }

        [HttpGet("get_current_rate")]
        public async Task<float> GetRate()
        {
            try
            {
                var rate = _repository.GetDateFromDatabase().Mid;
                return rate;
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}
