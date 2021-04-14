using Common.Models;
using System;
using System.Collections.Generic;

namespace Common.Contracts.Services
{
    public interface IPnLReportService
    {
        IEnumerable<PnLReport> GetReport(string symbol, DateTime asofDate);
    }
}
