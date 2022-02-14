using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsWeb
{
    [TestClass]
    public class UnitTest2
    {
        private readonly Context _context;

        public CurrenciesTest(Context context)
        {
            _context = context;
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
