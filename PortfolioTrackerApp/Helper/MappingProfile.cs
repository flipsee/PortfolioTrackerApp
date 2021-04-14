using AutoMapper;
using Common.Models;
using PortfolioTrackerApp.ViewModel;

namespace PortfolioTrackerApp.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<TradeVM, Trade>().ReverseMap();
            CreateMap<Trade, PortfolioTradeVM>()
                .ForMember(dest => dest.Ticker, opt => opt.MapFrom(src => src.Ticker.Symbol)) 
                .ReverseMap();
        }
    }
}
