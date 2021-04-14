namespace Common.Models
{
    public class Portfolio: BaseModel
    {
        public string Name { get; set; }
        public int TickerId { get; set; }
        public Ticker Ticker { get; set; }
    }
}
