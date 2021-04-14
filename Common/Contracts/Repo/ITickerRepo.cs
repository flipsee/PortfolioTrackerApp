using Common.Models;
using System.Collections.Generic;

namespace Common.Contracts.Repo
{
    public interface ITickerRepo: IBaseRepo<Ticker>
    {
        ICollection<Ticker> FindBySymbol(string symbol);
        Ticker GetBySymbol(string symbol);
    }
}
