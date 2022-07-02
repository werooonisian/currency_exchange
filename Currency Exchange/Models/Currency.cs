using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Exchange.Models
{
    [Table("Currency")]
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public ICollection<Rate> Rates { get; set; }
    }
}
