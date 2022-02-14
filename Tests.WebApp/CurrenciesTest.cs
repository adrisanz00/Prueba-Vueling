using DataDBContext;
using DataModels.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Implementations;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Tests.WebApp
{
    [TestClass]
    public class CurrenciesTest
    {

        [TestMethod]
        public void TestGetCurrencies()
        {
            List<ModelCurrency> currencies = ReadXMLHelper.GetCurrenciesXML(); 
            Task<List<ModelCurrency>> currenciesTask = Task.FromResult(currencies);
            Mock<ICurrenciesService> serviceMock = new Mock<ICurrenciesService>();
            serviceMock.Setup(mock => mock.GetCurrencies()).Returns(currenciesTask);

            Assert.AreEqual(currencies, currenciesTask.Result);
        }
    }
}