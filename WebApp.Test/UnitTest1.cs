using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [TestMethod]
        public void TestMethod1()
        {
            var a = 1;
            Assert.AreEqual(1, a);
        }

        [TestMethod]
        public void TestGetCurrencies()
        {
            List<ModelCurrency> currencies = _context.Currencies.ToList();
            Task<List<ModelCurrency>> currenciesTask = Task.FromResult(currencies);
            Mock<ICurrenciesService> serviceMock = new Mock<ICurrenciesService>();
            serviceMock.Setup(mock => mock.GetCurrencies()).Returns(currenciesTask);

            Assert.AreEqual(_context.Currencies.ToList(), currencies);
        }
    }
}
