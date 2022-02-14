using DataDBContext;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.ErrorHandling;

namespace Utils
{
    public static class InsertDBHelper
    {
        public static void InsertDbCurrencies(Context _context)
        {
            List<ModelCurrency> currencies = ReadXMLHelper.GetCurrenciesXML();
            try
            {
                if (currencies.Count > 0)
            {
                foreach (var currency in _context.Currencies)
                {
                    _context.Currencies.Remove(currency);
                }

                _context.SaveChanges();

                foreach (var currency in currencies)
                {

                    _context.Currencies.Add(currency);
                }
                _context.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }
        }
        public static void InsertDbTransactions(Context _context)
        {
            List<ModelTransaction> transactions = ReadXMLHelper.GetTransactionsXML();
            try
            {
                if (transactions.Count > 0)
                {
                    foreach (var item in _context.Transactions)
                    {
                        _context.Transactions.Remove(item);
                    }

                    _context.SaveChanges();

                    foreach (var transaction in transactions)
                    {

                        _context.Transactions.Add(transaction);
                    }
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }
        }
    }
}
