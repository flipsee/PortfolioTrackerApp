using Common.Helper;
using Common.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class TimeSeriesData
    {
        public TimeSeriesData() { }
        public TimeSeriesData(JObject json)
        {
            MetaData = new MetaData(json);
            PriceDetails = new List<PriceHistory>();

            foreach (var item in json.Last.First.Children())
            {
                var temp = item.ToObject<JProperty>();
                PriceDetails.Add(new PriceHistory(item, temp.Name, MetaData));
            }
        }

        public MetaData MetaData { get; set; }
        public List<PriceHistory> PriceDetails { get; set; }
    }

    public class MetaData : BaseModel
    {
        public MetaData() { }
        public MetaData(JObject json)
        {
            var token = json.First.First;
            Information = token.Value<string>("1. Information");
            Symbol = token.Value<string>("2. Symbol");
            LastRefreshed = token.Value<DateTime>("3. Last Refreshed");
            OutputSize = token.Value<string>("4. Output Size");
            TimeZone = token.Value<string>("5. Time Zone");
            var temp = json.Last.ToObject<JProperty>();
            DataInterval = Utils.GetSubstringByString("(", ")", temp.Name);
        }

        public string Information;
        public string Symbol;
        public DateTime LastRefreshed;
        public string OutputSize;
        public string TimeZone;
        public string DataInterval;
    }

    public class PriceHistory : BaseModel
    {
        public PriceHistory() { }
        public PriceHistory(JToken token, string priceDateTime, MetaData metaData)
        {
            PriceDateTime = DateTime.Parse(priceDateTime);
            Symbol = metaData.Symbol;
            Open = token.First.Value<decimal>("1. open");
            High = token.First.Value<decimal>("2. high");
            Low = token.First.Value<decimal>("3. low");
            Close = token.First.Value<decimal>("4. close");

            if (metaData.DataInterval == "Daily")
            {
                AdjustedClose = token.First.Value<decimal?>("5. adjusted close") ?? 100;
                Volume = token.First.Value<int>("6. volume");
                DividendAmount = token.First.Value<decimal?>("7. dividend amount") ?? 100;
                SplitCoefficient = token.First.Value<decimal?>("8. split coefficient") ?? 100;
            }
            else
                Volume = token.First.Value<int>("5. volume");
        }

        public string Symbol;
        public DateTime PriceDateTime;
        public decimal Open;
        public decimal High;
        public decimal Low;
        public decimal Close;
        public decimal? AdjustedClose;
        public int Volume;
        public decimal? DividendAmount;
        public decimal? SplitCoefficient;
    }
}
