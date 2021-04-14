using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.MarketData
{
    public interface IMarketDataProvider
    {
        void GetAllListing();
        void GetListing(string tickerSymbol);
        void GetDailyPrice(string tickerSymbol);
        void GetIntraDayPrice(string tickerSymbol);
    }
}
