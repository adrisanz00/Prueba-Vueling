using DataDBContext;
using DataModels.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTests
{
    [TestClass]
    public class CurrenciesTest
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

            NUnit.Framework.Assert.AreEqual(_context.Currencies.ToList(), currencies);
        }
    }
}
