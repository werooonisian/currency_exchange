using Currency_Exchange.Data;
using Currency_Exchange.Models;
using Currency_Exchange.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 
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
        private readonly CurrencyService _service;

        private readonly AppDbContext _context;

        public HomeController(CurrencyService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("get_current_rate")]
        public async Task<Rate> GetRate()
        {
            if(!_context.Currency.Any())
            {
                await _service.AddDataToDatabase();
            }
            else
            {
                await _service.UpdateDateInDatabase();
            }

            return await _service.GetRate();
        }

    }
}
