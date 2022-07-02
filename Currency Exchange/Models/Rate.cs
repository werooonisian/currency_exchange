using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Exchange.Models
{
    [Table("Rates")]
    public class Rate
    {
        public int Id { get; set; }
        public float Mid { get; set; }
        public string EffectiveDate { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
