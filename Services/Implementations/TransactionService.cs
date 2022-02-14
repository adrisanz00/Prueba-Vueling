using DataDBContext;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Services.Interfaces;
using Utils;
using WebApplication2.ErrorHandling;

namespace Services.Implementations
{
    public class TransactionService : ITransactionsService
    {
        private readonly Context _context;

        public TransactionService(Context context)
        {
            _context = context;
        }

        public Task<List<ModelTransaction>> GetTransactions()
        {
            InsertDBHelper.InsertDbTransactions(_context);
            return _context.Transactions.ToListAsync();
        }

        public string GetTransactionsBySKU(string SKU)
        {
            string json ="";
            try
            {
                List<ModelTransaction> skuTransactions = _context
                  .Transactions
                  .Where(transaction => transaction.SKU == SKU)
                  .ToList();

                List<ModelTransaction> transformatedTransactions = MoneyTransformationHelper.GetTransactionListBySku(skuTransactions, _context);

                
                json = JsonConvert.SerializeObject(new
                {
                    results = transformatedTransactions,
                    totalAmount = MoneyTransformationHelper.CalculateTotalAmount(transformatedTransactions)

                });
            }
            catch (Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }
            return json;
        }
    }
}
