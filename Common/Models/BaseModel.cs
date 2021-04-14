using Common.Contracts.Models;
using System;

namespace Common.Models
{

    public abstract class BaseModel: IBaseModel
    {
        public int Id { get; set; }

        public DateTime AddDateTime_UTC { get; set; }
        public string AddBy { get; set; }

        public DateTime ModDateTime_UTC { get; set; }
        public string ModBy { get; set; }

        public bool Disabled { get; set; } = false;
    }
}
