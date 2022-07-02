using Currency_Exchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Exchange.Data
{
    public interface ICurrencyRepository
    {
        Currency AddCurrencyToDatabase(Currency currency);
        Currency UpdateCurrency(Currency currency);
        Currency GetByCode(string code);
        Rate GetByCurrencyId(int CurrencyId);
        Rate UpdateCurrencyRate(Rate rate);
        Rate GetDateFromDatabase();

    }
}
