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

    }
}
