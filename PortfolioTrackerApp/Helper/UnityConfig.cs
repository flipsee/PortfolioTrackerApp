using AutoMapper;
using Common.Contracts;
using Common.Contracts.MarketData;
using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Helper;
using Infrastructure.MarketData;
using Infrastructure.Repo;
using Service.Services;
using Unity;
using Unity.Lifetime;

namespace PortfolioTrackerApp.Helper
{
    public class UnityConfig
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<frmPortfolio>();
            container.RegisterType<frmAddTrade>();

            container.RegisterType(typeof(IBaseRepo<>), typeof(BaseXMLRepo<>), new ContainerControlledLifetimeManager()); //Generic Repo
            container.RegisterType(typeof(IBaseCRUDService<>), typeof(BaseCRUDService<>)); //Generic CRUD Service
            container.RegisterType(typeof(IModelMapper<,>), typeof(ModelMapper<,>));
            container.RegisterType(typeof(IModelMapper), typeof(ModelMapper));

            container.RegisterFactory<ILogger>(c => Utils.Logger);

            container.RegisterType<IMarketDataProvider, AlphaVantage>();
                       
            container.RegisterType<ITickerRepo, TickerRepo>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITradeRepo, TradeRepo>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITradeSummaryRepo, TradeSummaryRepo>(new ContainerControlledLifetimeManager());
            container.RegisterType<ITradeSummaryAuditRepo, TradeSummaryAuditRepo>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPnLReportRepo, PnLReportRepo>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IPortfolioRepo, BaseXMLRepo<Portfolio>>();

            container.RegisterType<IMarketDataService, MarketDataService>();
            container.RegisterType<ITickerService, TickerService>();
            container.RegisterType<ITradeService, TradeService>();
            container.RegisterType<IPortfolioService, PortfolioService> ();
            container.RegisterType<IPnLReportService, PnLReportService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile()); 
            });
            container.RegisterInstance<IMapper>(mappingConfig.CreateMapper());

            return container;
        }
    }    
}
