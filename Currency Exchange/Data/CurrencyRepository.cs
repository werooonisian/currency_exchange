using Currency_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Exchange.Data
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AppDbContext _context;

        public CurrencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public Currency AddCurrencyToDatabase(Currency currency)
        {
            _context.Currency.Add(currency);
            currency.Id = _context.SaveChanges();
            return currency;
        }

        public Currency UpdateCurrency(Currency currency)
        {
            _context.Currency.Update(currency);
            _context.SaveChanges();
            return currency;
        }

        public Currency GetByCode(string Code)
        {
            return _context.Currency.FirstOrDefault(c => c.Code == Code);
        }

        public Rate GetByCurrencyId(int CurrencyId)
        {
            return _context.Rates.FirstOrDefault(r => r.CurrencyId == CurrencyId);
        }

        public Rate UpdateCurrencyRate(Rate rate)
        {
            _context.Rates.Update(rate);
            _context.SaveChanges();
            return rate;
        }

        public Rate GetDateFromDatabase()
        {
            return _context.Rates.FirstOrDefault();
        }
    }
}
