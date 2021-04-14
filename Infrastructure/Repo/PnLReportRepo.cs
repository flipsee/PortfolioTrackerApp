using Common.Contracts.Repo;
using Common.Models;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repo
{
    public class PnLReportRepo: IPnLReportRepo
    {
        private readonly ITradeSummaryRepo tradeSummaryRepo;
        private readonly IBaseRepo<PriceHistory> priceHistoryRepo;

        public PnLReportRepo(ITradeSummaryRepo tradeSummaryRepo, IBaseRepo<PriceHistory> priceHistoryRepo)
        {
            this.tradeSummaryRepo = tradeSummaryRepo;
            this.priceHistoryRepo = priceHistoryRepo;
        }

        public IEnumerable<PnLReport> GetReport(string symbol, DateTime asofDate)
        {
            var tradesum = tradeSummaryRepo.GetAll();
            var priceHistory = priceHistoryRepo.GetAll();
            
            var result = from t1 in tradesum
                         join t2 in priceHistory
                            on t1.Ticker.Symbol equals t2.Symbol into ps
                         from t2 in ps.DefaultIfEmpty()
                         where (t1.Ticker.Symbol == symbol || symbol == "--All--")
                         select new PnLReport {
                            Ticker = t1.Ticker.Symbol,
                            AsOfDate = t2.PriceDateTime,
                            TotalAmount = t1.Quantity * t1.UnitPrice,
                            TotalAmountwCost = t1.Quantity * t1.UnitPriceWithCost,
                            Quantity = t1.Quantity,
                            Price = t2.Open,
                            PrevClose = t2.Close,
                         };
            return result.Where(p=> p.AsOfDate.Date == asofDate.Date).ToList();
        }
    }
}
