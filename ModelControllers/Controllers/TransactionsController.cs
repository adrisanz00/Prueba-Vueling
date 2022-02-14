using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ModelControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;

        }
        [HttpGet]
        public async Task<List<ModelTransaction>> GetTransacciones()
        {
            return await _transactionsService.GetTransactions();
        }

        [HttpGet("getBySKU/{SKU}")]
        public string GetTransactionsBySKU(string SKU)
        {
           return  _transactionsService.GetTransactionsBySKU(SKU);
        }

    }
}
