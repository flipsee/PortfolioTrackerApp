using Common.Contracts.MarketData;
using Common.Contracts.Services;
using System.Linq;

namespace Service.Services
{
    public class MarketDataService: IMarketDataService
    {
        private readonly IMarketDataProvider provider;
        private readonly IPortfolioService portfolioSvc;

        public MarketDataService(IMarketDataProvider provider, IPortfolioService portfolioSvc) 
        {
            this.provider = provider;
            this.portfolioSvc = portfolioSvc;
        }

        public void GetAllListing()
        {
            provider.GetAllListing();
        }

        public void GetDailyPrice(string tickerSymbol)
        {
            provider.GetDailyPrice(tickerSymbol);
        }

        public void GetIntraDayPrice(string tickerSymbol)
        {
            provider.GetIntraDayPrice(tickerSymbol);
        }

        public void GetListing(string tickerSymbol)
        {
            provider.GetListing(tickerSymbol);
        }

        public void GetPortfolioDailyPrice()
        {
            var portfolio = portfolioSvc.GetAll().Select(p=> p.Ticker.Symbol).Distinct();
            if (portfolio != null && portfolio.Count() > 0)
                foreach(var p in portfolio)
                    provider.GetDailyPrice(p);
        }
    }
}
