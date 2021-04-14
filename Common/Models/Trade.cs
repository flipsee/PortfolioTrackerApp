using System;

namespace Common.Models
{
    public class Trade: BaseModel
    {
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }

        public DateTime TradeDate { get; set; }

        public string TradeType { get; set; }
        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TransactionAmount { get; set; } // Quantity * UnitPrice 

        public decimal? OtherCostperUnit { get; set; } //Broker, clearing cost etc per unit
        public decimal? TotalOtherCost { get; set; } //total cost per transaction
        public decimal TransactionAmountWithCost { get; set; } // TransactionAmount + Total Other Cost
        public decimal UnitPriceWithCost { get; set; } // TotalTransactionAmount / Quantity
    }

    public class TradeSummary : BaseModel
    {
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceWithCost { get; set; }

    }

    public class TradeSummaryAudit : BaseModel
    {
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }

        public int? TradeSummaryId { get; set; }

        public string MovementType { get; set; } //BUY, Sell, Adjustment
        
        public int OldQuantity { get; set; }
        public decimal OldUnitPrice { get; set; }
        public decimal OldUnitPriceWithCost { get; set; }

        public int? TradeId { get; set; }
        public int TradeQuantity { get; set; }
        public decimal TradeUnitPrice { get; set; }
        public decimal TradePriceWithCost { get; set; }

        public int NewQuantity { get; set; }
        public decimal NewUnitPrice { get; set; }
        public decimal NewUnitPriceWithCost { get; set; }
    }
}
