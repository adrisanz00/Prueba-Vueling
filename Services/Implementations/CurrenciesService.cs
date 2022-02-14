using DataDBContext;
using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Utils;

namespace Services.Implementations
{
    public class CurrenciesService : ICurrenciesService
    {
        private readonly Context _context;

        public CurrenciesService(Context context) 
        {
            _context = context;
        }
        public Task<List<ModelCurrency>> GetCurrencies()
        {
            InsertDBHelper.InsertDbCurrencies(_context);
            return _context.Currencies.ToListAsync();
        }

    }
}
