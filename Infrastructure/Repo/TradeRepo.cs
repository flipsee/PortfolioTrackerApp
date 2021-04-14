using Common.Contracts;
using Common.Contracts.Repo;
using Common.Models;
using Common.Sessions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repo
{
    public class TradeRepo: BaseXMLRepo<Trade>, ITradeRepo
    {
        public TradeRepo(SessionProvider session, ILogger logger) : base(session, logger) { }
    }

    public class TradeSummaryAuditRepo : BaseXMLRepo<TradeSummaryAudit>, ITradeSummaryAuditRepo
    {
        public TradeSummaryAuditRepo(SessionProvider session, ILogger logger) : base(session, logger) { }
    }

    public class TradeSummaryRepo : BaseXMLRepo<TradeSummary>, ITradeSummaryRepo
    {
        private readonly ITickerRepo tickerRepo;
        public TradeSummaryRepo(SessionProvider session, ILogger logger, ITickerRepo tickerRepo) : base(session, logger) 
        {
            this.tickerRepo = tickerRepo;
        }        

        public ICollection<TradeSummary> FindBySymbol(string symbol)
        {
            var tickers = tickerRepo.GetAll();
            var summary = GetAll();
            var result = from t1 in tickers
                         join t2 in summary
                            on t1.Id equals t2.TickerId
                         where t1.Symbol.Contains(symbol)
                         select t2;
            return result.ToList(); 
        }

        public TradeSummary GetBySymbol(string symbol)
        {
            var tickers = tickerRepo.GetAll();
            var summary = GetAll();
            var result = from t1 in tickers
                         join t2 in summary
                            on t1.Id equals t2.TickerId
                         where t1.Symbol == symbol
                         select t2;
            return result.FirstOrDefault();
        }

        public TradeSummary GetByTickerId(int tickerId)
        {
            return GetAll().Where(p => p.TickerId == tickerId).FirstOrDefault();
        }
    }
}
