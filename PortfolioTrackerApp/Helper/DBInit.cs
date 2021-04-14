using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Helper;
using Common.Models;
using Infrastructure.Entities;
using System;

namespace PortfolioTrackerApp.Helper
{
    public class DBInit 
    {
        private readonly IMarketDataService marketDataSvc;
        private readonly ITickerService tickerSvc;
        private readonly IPortfolioService PortfolioSvc;
        private readonly ITradeService tradeSvc; 

        public DBInit(IMarketDataService marketDataSvc,
            ITickerService tickerSvc,
            IPortfolioService PortfolioSvc,
            ITradeService tradeSvc)
        {
            this.marketDataSvc = marketDataSvc;
            this.tickerSvc = tickerSvc;
            this.PortfolioSvc = PortfolioSvc;
            this.tradeSvc = tradeSvc; 
            xmlDBInit();
        }

        public void xmlDBInit()
        {
            ///1. Ticker
            var ticker = this.tickerSvc.GetAll();
            if (ticker.Count == 0)
                marketDataSvc.GetAllListing();

            var msftTicker = tickerSvc.GetBySymbol("MSFT");
            var googTicker = tickerSvc.GetBySymbol("GOOG");

            ///2. Portfolio
            var portfolio = this.PortfolioSvc.GetAll();
            if (portfolio.Count == 0)
            {                
                PortfolioSvc.Add(new Portfolio()
                {
                    Name = "Tech Stocks",
                    TickerId = msftTicker.Id,
                    Ticker = msftTicker
                });

                PortfolioSvc.Add(new Portfolio()
                {
                    Name = "Tech Stocks",
                    TickerId = googTicker.Id,
                    Ticker = googTicker
                });
            }

            ///3. Trade, Summary, Audit
            var trades = this.tradeSvc.GetAll();
            if (trades.Count == 0)
            {
                tradeSvc.Add(new Trade()
                {
                    TickerId = msftTicker.Id,
                    Ticker = msftTicker,
                    TradeDate = new DateTime(2018,1,2),
                    TradeType = TradeType.Buy.ToString(),
                    Quantity = 100,
                    UnitPrice = 85.95m,
                    //OtherCostperUnit = 0,
                    //TotalOtherCost = 0                    
                });

                tradeSvc.Add(new Trade()
                {
                    TickerId = googTicker.Id,
                    Ticker = googTicker,
                    TradeDate = new DateTime(2018, 1, 2),
                    TradeType = TradeType.Buy.ToString(),
                    Quantity = 50,
                    UnitPrice = 1065m,
                    //OtherCostperUnit = 15,
                    //TotalOtherCost = 0                    
                });

                tradeSvc.Add(new Trade()
                {
                    TickerId = msftTicker.Id,
                    Ticker = msftTicker,
                    TradeDate = new DateTime(2018, 1, 10),
                    TradeType = TradeType.Buy.ToString(),
                    Quantity = 150,
                    UnitPrice = 87.82m,
                    //OtherCostperUnit = 0,
                    //TotalOtherCost = 0                    
                });

                marketDataSvc.GetPortfolioDailyPrice();
            }                            
        }
    }
    
}
