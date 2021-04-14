using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Models;

namespace Service.Services
{
    public class PortfolioService : BaseCRUDService<Portfolio>, IPortfolioService
    {
        private readonly ITradeService tradeSvc;
        public PortfolioService(IBaseRepo<Portfolio> repo, ITradeService tradeSvc) : base(repo) 
        {
            this.tradeSvc = tradeSvc;
        }
    }
}
