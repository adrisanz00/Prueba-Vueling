using DataModels.Models;

namespace Services.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<ModelTransaction>> GetTransactions();
        string GetTransactionsBySKU(string SKU);
    }
}
