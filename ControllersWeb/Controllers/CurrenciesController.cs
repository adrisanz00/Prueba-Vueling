using DataContext;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControllersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly Context _context;

        public CurrenciesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelCurrency>>> GetCurrencies()
        {
            //Helpers.InsertDbCurrencies(_context);
            return await _context.Currencies.ToListAsync();
        }
    }
}
