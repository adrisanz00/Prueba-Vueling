using DataDBContext;
using DataModels.Models;
using WebApplication2.ErrorHandling;

namespace Utils
{
    public static class MoneyTransformationHelper
    {
       
       
        public static double CalculateTotalAmount(List<ModelTransaction> transformatedTransactions)
        {
            double totalAmount = 0;
            foreach (var transaction in transformatedTransactions)
            {
                totalAmount += transaction.Amount;
            }
            return Math.Round(totalAmount, 2);
        }
        public static List<ModelTransaction> GetTransactionListBySku(List<ModelTransaction> skuTransactions, Context _context)
        {

            ModelCurrency currency = new ModelCurrency();
            List<ModelTransaction> transactionList = new List<ModelTransaction>();
            try
            {
                foreach (var transaction in skuTransactions)
                {
                    transactionList.Add(GetTransformatedModel(transaction, _context));
                }
            }catch (Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }
            return transactionList;
        }
        public static ModelTransaction GetTransformatedModel(ModelTransaction transaction, Context _context)
        {
            ModelCurrency currency = _context.Currencies.Where(x => x.From == transaction.Currency).FirstOrDefault();
            transaction.Amount =  currency.Rate * transaction.Amount;
            transaction.Currency = currency.To;

            if (!transaction.Currency.Equals("EUR"))
            {
                GetTransformatedModel(transaction, _context);
            }

            return transaction;
        }
    }
}
