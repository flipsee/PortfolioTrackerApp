using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Contracts.Repo
{
    public interface IPnLReportRepo
    {
        IEnumerable<PnLReport> GetReport(string symbol, DateTime asofDate);
    }
}
