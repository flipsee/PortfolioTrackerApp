using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Models;
using System.Collections.Generic;

namespace Service.Services
{
    public class TickerService : BaseCRUDService<Ticker>, ITickerService
    {
        protected new readonly ITickerRepo repo;
        public TickerService(ITickerRepo repo) : base(repo) 
        {
            this.repo = repo;
        }

        public ICollection<Ticker> FindBySymbol(string ticker)
        {
            return repo.FindBySymbol(ticker);
        }

        public Ticker GetBySymbol(string ticker)
        {
            return repo.GetBySymbol(ticker);
        }
    }
}
