using Common.Contracts;
using Common.Contracts.Repo;
using Common.Models;
using Common.Sessions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repo
{
    public class TickerRepo: BaseXMLRepo<Ticker>, ITickerRepo
    {
        public TickerRepo(SessionProvider session, ILogger logger) : base(session, logger) { }

        public ICollection<Ticker> FindBySymbol(string ticker)
        {
            return GetAll().Where(p => p.Symbol.Contains(ticker)).ToList();
        }

        public Ticker GetBySymbol(string symbol)
        {
            return GetAll().Where(p => p.Symbol == symbol).FirstOrDefault();
        }

    }
}
