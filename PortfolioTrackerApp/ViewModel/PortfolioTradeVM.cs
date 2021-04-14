using System;

namespace PortfolioTrackerApp.ViewModel
{
    public class PortfolioTradeVM
    {
        public string Ticker { get; set; }

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
}
