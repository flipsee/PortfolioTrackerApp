using Common.Contracts;
using Common.Contracts.Services;
using Common.Models;
using PortfolioTrackerApp.Helper;
using PortfolioTrackerApp.ViewModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PortfolioTrackerApp
{
    public partial class frmPortfolio : Form
    {
        private readonly IPortfolioService portfolioSvc;
        private readonly ITradeService tradeSvc;
        private readonly ITickerService tickerSvc;
        private readonly IModelMapper mapper;
        private readonly frmAddTrade frmAddTrade;
        private readonly IPnLReportService pnlReportSvc;

        public frmPortfolio(IModelMapper mapper, frmAddTrade frmAddTrade
            , ITickerService tickerSvc
            , IPortfolioService portfolioSvc
            , ITradeService tradeSvc
            , IPnLReportService pnlReportSvc)
        {
            InitializeComponent();
            this.tickerSvc = tickerSvc;
            this.portfolioSvc = portfolioSvc;
            this.tradeSvc = tradeSvc;
            this.mapper = mapper;
            this.frmAddTrade = frmAddTrade;
            this.pnlReportSvc = pnlReportSvc;

            dtPnLAsOfDate.Value = new DateTime(2021, 04, 12);
        }

        public void ResetForm()
        {
            var tickers = this.tickerSvc.GetAll().ToList();
            tickers.Insert(0, new Ticker() { Symbol = "--All--", Id=-1 });
            cmbTicker.DataSource = tickers;
            cmbTicker.DisplayMember = "Symbol";
            cmbTicker.ValueMember = "Id"; 

            bindPortfolioGrid();
            bindPnLReportGrid();
        }

        private void bindPortfolioGrid()
        {
            var trades = tradeSvc.GetAll();
            dgvPortfolio.DataSource = this.mapper.Map<Trade,PortfolioTradeVM>(trades.ToList());
        }

        private void bindPnLReportGrid()
        {
            //var tickerId = ((Ticker)cmbTicker.SelectedItem).Id;
            var symbol = ((Ticker)cmbTicker.SelectedItem).Symbol;
            var asofDate = dtPnLAsOfDate.Value.Date;

            var report = pnlReportSvc.GetReport(symbol, asofDate);
            dgvPnL.DataSource = report;
        }


        private void btsAddPortfolioItem_Click(object sender, EventArgs e)
        {
            frmAddTrade.Show();
        }

        private void btnPnLSearch_Click(object sender, EventArgs e)
        {
            bindPnLReportGrid();
        }

    }
}
