using DataContext;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly Context _context;

        public TransactionsController(Context context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelTransaction>>> GetTransacciones()
        {
            //Helpers.InsertDbTransactions(_context);
            return await _context.Transactions.ToListAsync();
        }

        [HttpGet("getBySKU/{SKU}")]
        public async void GetTransactionsBySKU(string SKU)
        {

            //List<ModelTransaction> skuTransactions = _context
            //   .Transactions
            //   .Where(transaction => transaction.SKU == SKU)
            //   .ToList();

            //List<ModelTransaction> transformatedTransactions = GetTransactionList(skuTransactions);

            //string json = JsonConvert.SerializeObject(new
            //{
            //    results = transformatedTransactions,
            //    totalAmount = Helpers.CalculateTotalAmount(transformatedTransactions)

            //});
            //return json;
        }
    }
}
