using Currency_Exchange.Data;
using Currency_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Exchange.Services
{
    public class CurrencyService
    {
        private readonly ICurrencyRepository _repository;

        public CurrencyService(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDataToDatabase()
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

        public async Task UpdateDateInDatabase()
        {
            Rate rate = _repository.GetDateFromDatabase();

            if (DateTime.Now.ToString("yyyy-MM-dd") != rate.EffectiveDate)
            {

                ApiHelper.InicializedClient();

                var currency = await CurrencyProcessor.LoadData();

                Currency currency_from_db = _repository.GetByCode(currency.Code);
                Rate rate_from_db = _repository.GetByCurrencyId(currency_from_db.Id);

                rate_from_db.EffectiveDate = currency.Rates.FirstOrDefault().EffectiveDate;
                rate_from_db.Mid = currency.Rates.FirstOrDefault().Mid;

                _repository.UpdateCurrencyRate(rate_from_db);
            }
        }

        public async Task<Rate> GetRate()
        {
            try
            {
                var rate = _repository.GetDateFromDatabase();
                return rate;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
