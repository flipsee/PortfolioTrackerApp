using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Helper;
using Common.Models;

namespace Service.Services
{
    public class TradeService: BaseCRUDService<Trade>, ITradeService
    {
        //private new ITradeRepo repo;
        private readonly ITradeSummaryAuditRepo tradeSummaryAuditRepo;
        private readonly ITradeSummaryRepo tradeSummaryRepo; 

        public TradeService(ITradeRepo repo,
            ITradeSummaryAuditRepo tradeSummaryAuditRepo,
            ITradeSummaryRepo tradeSummaryRepo ) : base(repo) 
        {
            //this.repo = repo;
            this.tradeSummaryAuditRepo = tradeSummaryAuditRepo;
            this.tradeSummaryRepo = tradeSummaryRepo; 
        }

        ///CRUD trade
        ///entry to TradeSummaryAudit
        ///entry to TradeSummary

        protected override void BasePreProcessing(ref Trade entity, OperationType operationType)
        {
            ///for operation trade we will need to: 
            ///1. calculate: 
            /// TransactionAmount 
            /// TotalTransactionAmount
            /// UnitPriceWithCost
            entity.TransactionAmount = entity.Quantity * entity.UnitPrice;
            entity.TransactionAmountWithCost = entity.TransactionAmount;
            if (entity.OtherCostperUnit != null && entity.OtherCostperUnit > 0)
            {
                entity.TotalOtherCost = entity.OtherCostperUnit * entity.Quantity;
                entity.TransactionAmountWithCost = entity.TransactionAmount + (entity.OtherCostperUnit * entity.Quantity) ?? entity.TransactionAmount;                
            } 
            else if (entity.TotalOtherCost != null && entity.TotalOtherCost > 0)
            {
                entity.OtherCostperUnit = entity.OtherCostperUnit / entity.Quantity;
                entity.TransactionAmountWithCost = entity.TransactionAmount + entity.TotalOtherCost ?? entity.TransactionAmount;                
            }
            entity.UnitPriceWithCost = entity.TransactionAmountWithCost / entity.Quantity;
        }

        protected override void BasePostProcessing(ref Trade entity, OperationType operationType)
        {
            ///2. add entry to TradeSummaryAudit
            ///3. calculate the TradeSummary
            var tickerTradeSummary = tradeSummaryRepo.GetByTickerId(entity.TickerId);
            if (tickerTradeSummary == null || tickerTradeSummary.Id == 0)
            {
                tickerTradeSummary = new TradeSummary()
                {
                    TickerId = entity.TickerId,
                    Ticker = entity.Ticker,
                    Quantity = 0,
                    UnitPrice = 0,
                    UnitPriceWithCost = 0
                };
            }
            
            var tradeaudit = new TradeSummaryAudit()
            {                
                TickerId = entity.TickerId,
                Ticker = entity.Ticker, 
                MovementType = operationType.ToString(),
                
                OldQuantity = tickerTradeSummary != null ? tickerTradeSummary.Quantity: 0,
                OldUnitPrice = tickerTradeSummary != null ? tickerTradeSummary.UnitPrice: 0,
                OldUnitPriceWithCost = tickerTradeSummary != null ? tickerTradeSummary.UnitPriceWithCost: 0,

                TradeId = entity.Id,
                TradeQuantity = entity.Quantity,
                TradeUnitPrice = entity.UnitPrice,
                TradePriceWithCost = entity.UnitPriceWithCost,
            };

            if (entity.TradeType == TradeType.Buy.ToString())
            {
                tickerTradeSummary.UnitPrice = ((tickerTradeSummary.UnitPrice * tickerTradeSummary.Quantity) + (entity.UnitPrice * entity.Quantity)) / (tickerTradeSummary.Quantity + entity.Quantity);
                tickerTradeSummary.UnitPriceWithCost = ((tickerTradeSummary.UnitPriceWithCost * tickerTradeSummary.Quantity) + (entity.UnitPriceWithCost * entity.Quantity)) / (tickerTradeSummary.Quantity + entity.Quantity);
                tickerTradeSummary.Quantity = tickerTradeSummary.Quantity + entity.Quantity;
            }
            else if (entity.TradeType == TradeType.Sell.ToString())
            {
                tickerTradeSummary.Quantity = tickerTradeSummary.Quantity - entity.Quantity;
                //for sell transaction, just log the quantity reduced but the profit or loss should be track in separately as realized P & L
            }

            tradeaudit.NewQuantity = tickerTradeSummary.Quantity;
            tradeaudit.NewUnitPrice = tickerTradeSummary.UnitPrice;
            tradeaudit.NewUnitPriceWithCost = tickerTradeSummary.UnitPriceWithCost;
            
            if (tickerTradeSummary.Id == 0)
                tradeSummaryRepo.Add(tickerTradeSummary);
            else
                tradeSummaryRepo.Update(tickerTradeSummary);

            tradeaudit.TradeSummaryId = tickerTradeSummary.Id;
            tradeSummaryAuditRepo.Add(tradeaudit);

            tradeSummaryRepo.Commit();
            tradeSummaryAuditRepo.Commit();
        }

        protected override MessageObject<Trade> ValidateAdd(Trade entity)
        {
            var msg = new MessageObject<Trade>(entity);
            if (entity.Quantity <= 0)
                msg.AddMessage(MessageType.Error, "InvalidEntry", "Please enter valid Quantity");

            return msg;
        }

        protected override MessageObject<Trade> ValidateUpdate(Trade entity)
        {
            return ValidateAdd(entity); //same validation as Add
        }
    }
}
