using System; 

namespace Common.Contracts.Models
{
    public interface IBaseModel
    {
        int Id { get; set; }
        DateTime AddDateTime_UTC { get; set; }
        string AddBy { get; set; }

        DateTime ModDateTime_UTC { get; set; }
        string ModBy { get; set; }

        bool Disabled { get; set; }
    }

}
