using DataModels.Models;
using DataDBContext;
using DataModels.Models;
using System.Globalization;
using System.Xml;
using WebApplication2.ErrorHandling;

namespace Utils
{
    public static class ReadXMLHelper
    {
        public static List<ModelCurrency> GetCurrenciesXML()
        {
            XmlTextReader readerRate = new XmlTextReader("http://quiet-stone-2094.herokuapp.com/rates.xml");

            List<ModelCurrency> list = new List<ModelCurrency>();
            try
            {
                while (readerRate.Read())
                {
                    ModelCurrency rate = new ModelCurrency();
                    switch (readerRate.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + readerRate.Name);

                            while (readerRate.MoveToNextAttribute()) // Read the attributes.
                                switch (readerRate.Name)
                                {
                                    case "from":
                                        rate.From = readerRate.Value;
                                        break;
                                    case "to":
                                        rate.To = readerRate.Value;
                                        break;
                                    case "rate":
                                        rate.Rate = double.Parse(readerRate.Value, CultureInfo.InvariantCulture); ;
                                        break;
                                    case "":
                                        break;
                                }

                            list.Add(rate);
                            break;
                    }
                }
                list.RemoveAt(0);
            }
            catch (Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }
            return list;
        }

        public static List<ModelTransaction> GetTransactionsXML()
        {
            XmlTextReader readerTransaction = new XmlTextReader("http://quiet-stone-2094.herokuapp.com/transactions.xml");

            List<ModelTransaction> listTransaction = new List<ModelTransaction>();
            try
            {
                while (readerTransaction.Read())
                {
                    ModelTransaction transaction = new ModelTransaction();
                    switch (readerTransaction.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.

                            while (readerTransaction.MoveToNextAttribute()) // Read the attributes.

                                switch (readerTransaction.Name)
                                {
                                    case "sku":
                                        transaction.SKU = readerTransaction.Value;
                                        break;
                                    case "amount":
                                        transaction.Amount = double.Parse(readerTransaction.Value, CultureInfo.InvariantCulture);
                                        break;
                                    case "currency":
                                        transaction.Currency = readerTransaction.Value;
                                        break;
                                    case "":
                                        break;
                                }

                            listTransaction.Add(transaction);
                            break;
                    }
                }
                listTransaction.RemoveAt(0);
            }
            catch (Exception ex)
            {
                StreamWriter w = new StreamWriter("Log/error.txt");
                ErrorLog.save(ex.Message, w);
            }

            return listTransaction;
        }
    }
}
