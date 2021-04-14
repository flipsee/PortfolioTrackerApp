using Common.Contracts.MarketData;
using Common.Contracts.Repo;
using Common.Helper;
using Common.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Infrastructure.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Infrastructure.MarketData
{
    public class AlphaVantage : IMarketDataProvider
    {
        private readonly string apiKey;
        private readonly ITickerRepo tickerRepo;
        private readonly IBaseRepo<PriceHistory> priceHistoryRepo;

        public AlphaVantage(ITickerRepo tickerRepo, IBaseRepo<PriceHistory> priceHistoryRepo)
        {
            this.apiKey = Utils.GetStringConfig("MyAPIKey");
            this.tickerRepo = tickerRepo;
            this.priceHistoryRepo = priceHistoryRepo;
        }

        private List<Ticker> getAllListing()
        {
            List<Ticker> result;
            string fileName = "listing_status.csv";
            string uri = Utils.GetAPIResponseCSV($"https://www.alphavantage.co/query?function=LISTING_STATUS&apikey={apiKey}", fileName).Result;
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TickerMap>();
                result = csv.GetRecords<Ticker>().ToList();
            }
            return result;
        }

        public void GetAllListing()
        {
            var result = this.getAllListing();
            this.tickerRepo.Add(result);
            this.tickerRepo.Commit();
        }

        /// <summary>
        /// get stock Listing & Delisting Status    
        /// https://www.alphavantage.co/query?function=LISTING_STATUS&apikey=demo
        /// </summary>
        /// <param name="tickerSymbol"></param>
        public void GetListing(string tickerSymbol)
        {
            var result = this.getAllListing().FirstOrDefault(p => p.Symbol == tickerSymbol);
            if (result != null)
            {
                var temp = this.tickerRepo.GetBySymbol(tickerSymbol);
                if (temp != null && temp.Symbol == result.Symbol)
                    result.Id = temp.Id;
                this.tickerRepo.Update(result);
                this.tickerRepo.Commit();
            }            
        }

        private sealed class TickerMap : ClassMap<Ticker>
        {
            public TickerMap()
            {
                Map(m => m.Symbol).Name("symbol");
                Map(m => m.Name).Name("name");
                Map(m => m.Exchange).Name("exchange");
                Map(m => m.AssetType).Name("assetType");
                Map(m => m.IPODateText).Name("ipoDate");
                Map(m => m.DelistingDateText).Name("delistingDate");
                Map(m => m.Status).Name("status");
            }
        }

        /// <summary>
        /// Get/Refresh Daily stock price and update into the database
        /// API: TIME_SERIES_DAILY_ADJUSTED https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=IBM&apikey=demo
        /// </summary>
        /// <param name="tickerSymbol"></param>
        public void GetDailyPrice(string tickerSymbol) 
        {
            string result = Utils.GetAPIResponseString($"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={tickerSymbol}&apikey={apiKey}").Result;
            var data = timeSeriesParser(result);
            this.priceHistoryRepo.Add(data.PriceDetails);
            this.priceHistoryRepo.Commit();            
        }

        /// <summary>
        /// Get/Refresh Intraday stock price and update into the database 
        /// https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo
        /// </summary>
        /// <param name="tickerSymbol"></param>
        public void GetIntraDayPrice(string tickerSymbol)
        {
            string result = Utils.GetAPIResponseString($"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={tickerSymbol}&interval=5min&apikey={apiKey}").Result;
            var data = timeSeriesParser(result);
            this.priceHistoryRepo.Add(data.PriceDetails);
            this.priceHistoryRepo.Commit();
        }

        private TimeSeriesData timeSeriesParser(string data) => new TimeSeriesData(JObject.Parse(data));
               
    }
}
