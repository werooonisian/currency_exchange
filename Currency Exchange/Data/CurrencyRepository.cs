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
    }
}
