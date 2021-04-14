using Common.Contracts.Repo;
using Common.Contracts.Services;
using Common.Models;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class PnLReportService: IPnLReportService
    {
        private readonly IPnLReportRepo pnlReportRepo;

        public PnLReportService(IPnLReportRepo pnlReportRepo)
        {
            this.pnlReportRepo = pnlReportRepo;
        }

        public IEnumerable<PnLReport> GetReport(string symbol, DateTime asofDate)
        {
            return pnlReportRepo.GetReport(symbol, asofDate);
        }
    }
}
