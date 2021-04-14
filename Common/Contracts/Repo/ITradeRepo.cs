using Common.Models;
using System.Collections.Generic;

namespace Common.Contracts.Repo
{
    public interface ITradeRepo : IBaseRepo<Trade>
    {
    }

    public interface ITradeSummaryAuditRepo : IBaseRepo<TradeSummaryAudit>
    {
    }

    public interface ITradeSummaryRepo : IBaseRepo<TradeSummary>
    {
        ICollection<TradeSummary> FindBySymbol(string symbol);
        TradeSummary GetBySymbol(string symbol);
        TradeSummary GetByTickerId(int tickerId);
    }
}
