using DataDBContext;
using DataModels.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Tests.WebApp
{
    [TestClass]
    public class TransactionsTest
    {
        [TestMethod]
        public void TestGetTransactions()
        {
            List<ModelTransaction> transactions = ReadXMLHelper.GetTransactionsXML();
            Task<List<ModelTransaction>> transactionTask = Task.FromResult(transactions);
            Mock<ITransactionsService> serviceMock = new Mock<ITransactionsService>();
            serviceMock.Setup(mock => mock.GetTransactions()).Returns(transactionTask);

            Assert.AreEqual(transactions, transactionTask.Result);
        }

        [TestMethod]
        public void TestGetTransactionsBySku()
        {
            List<ModelTransaction> transactions = ReadXMLHelper.GetTransactionsXML();
            List<ModelTransaction> transactionsbySku = transactions.Where(x => x.SKU == "R9876").ToList();
            Task<List<ModelTransaction>> transactionTask = Task.FromResult(transactionsbySku);
            Mock<ITransactionsService> serviceMock = new Mock<ITransactionsService>();
            serviceMock.Setup(mock => mock.GetTransactionsBySKU("R9876")).Returns(transactionsbySku.ToString());

            Assert.AreEqual(transactionsbySku.ToString(), transactionTask.Result.ToString());
        }
            [TestMethod]
        public void TestTotalAmount()
        {
            List<ModelTransaction> list = new List<ModelTransaction>();
            list.Add(new ModelTransaction { SKU = "E234", Currency = "EUR", Amount = 242 });
            list.Add(new ModelTransaction { SKU = "E634", Currency = "EUR", Amount = 23 });
            list.Add(new ModelTransaction { SKU = "E734", Currency = "EUR", Amount = 1.34 });
            list.Add(new ModelTransaction { SKU = "E134", Currency = "EUR", Amount = 1.03 });
            double number = 267.37;

            Assert.IsTrue(MoneyTransformationHelper.CalculateTotalAmount(list) == number);
        }
    }
}
