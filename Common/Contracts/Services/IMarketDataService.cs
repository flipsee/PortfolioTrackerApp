namespace Common.Contracts.Services
{
    public interface IMarketDataService
    {
        void GetAllListing();
        void GetListing(string tickerSymbol);
        void GetDailyPrice(string tickerSymbol);
        void GetIntraDayPrice(string tickerSymbol);
        void GetPortfolioDailyPrice();
    }
}
