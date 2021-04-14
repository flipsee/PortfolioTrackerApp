using Common.Models;
using System.Collections.Generic;

namespace Common.Contracts.Services
{
    public interface ITickerService: IBaseCRUDService<Ticker>
    {
        ICollection<Ticker> FindBySymbol(string symbol);
        Ticker GetBySymbol(string ticker);
    }
}
