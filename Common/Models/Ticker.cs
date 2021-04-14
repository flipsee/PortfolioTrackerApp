using System; 

namespace Common.Models
{   

    public class Ticker : BaseModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }

        public string Exchange { get; set; }

        public string AssetType { get; set; }
        public string Status { get; set; }

        public string IPODateText { get; set; }
        public DateTime? IPODate {
            get
            {
                if (IPODateText != null || IPODateText != "null" || IPODateText != string.Empty)
                    return null;
                return DateTime.Parse(IPODateText);
            }
        }

        public string DelistingDateText { get; set; }
        public DateTime? DelistingDate {
            get
            {
                if (DelistingDateText != null || DelistingDateText != "null" || DelistingDateText != string.Empty)
                    return null;
                return DateTime.Parse(DelistingDateText);
            }
        }
    }
}
