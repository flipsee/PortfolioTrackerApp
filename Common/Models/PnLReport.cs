using System;

namespace Common.Models
{
    public class PnLReport
    {
        public string Ticker { get; set; }
        public DateTime AsOfDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountwCost { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue //Quantity * Price
        {
            get { return Quantity * Price; }
        } 

        public decimal PrevClose { get; set; }

        public decimal DailyPnL //(Price-PreviousClose) * Quantity
        { 
            get { return (Price - PrevClose) * Quantity; } 
        }

        public decimal InceptionPnL //MarketValue - TotalAmount
        { 
            get{ return MarketValue - TotalAmount; } 
        } 
    }
}
