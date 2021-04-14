using System;
using Common.Contracts.MarketData;
using Common.Contracts.Repo;
using Common.Helper;
using Common.Models;
using Common.Sessions;
using Infrastructure.Entities;
using Infrastructure.MarketData;
using Infrastructure.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Infrastructure.MarketData
{
    [TestClass]
    public class AlphaVantageTest
    {
        SessionProvider session = new SessionProvider();
        //private Mock<ITickerRepo> mTickerRepo;
        private IMarketDataProvider _alphaVantage;

        public AlphaVantageTest()
        {
            session.Initialise("Ivan", "my@Mail.com");
            //this.mTickerRepo = new Mock<ITickerRepo>();
            ITickerRepo tickerRepo = new TickerRepo(session, Utils.Logger);
            IBaseRepo<PriceHistory> priceHistoryRepo = new BaseXMLRepo<PriceHistory>(session, Utils.Logger);
            this._alphaVantage = new AlphaVantage(tickerRepo, priceHistoryRepo);            
        }

        [TestMethod]
        public void TestGetListing()
        {
            this._alphaVantage.GetListing("IBM");
            var result = "";

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetDailyPrice()
        {
            this._alphaVantage.GetDailyPrice("IBM");
            var result = "";               

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetIntraDayPrice()
        {
            this._alphaVantage.GetIntraDayPrice("IBM");
            var result = "";

            Assert.IsNotNull(result);
        }
    }
}
