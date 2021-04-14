using Common.Contracts;
using Common.Contracts.Services;
using Common.Helper;
using Common.Models;
using PortfolioTrackerApp.Helper;
using PortfolioTrackerApp.ViewModel;
using System;
using System.Windows.Forms;

namespace PortfolioTrackerApp
{
    public partial class frmAddTrade : Form
    {
        private readonly ITradeService tradeSvc;
        private readonly ITickerService tickerSvc;
        private readonly IModelMapper mapper;

        public frmAddTrade(IModelMapper mapper, ITradeService tradeSvc, ITickerService tickerSvc)
        {
            InitializeComponent();

            this.mapper = mapper;
            this.tradeSvc = tradeSvc;
            this.tickerSvc = tickerSvc;

            cmbTradeType.DataSource = Enum.GetValues(typeof(TradeType));
            cmbTicker.DataSource = this.tickerSvc.GetAll();
            cmbTicker.DisplayMember = "Symbol";
            cmbTicker.ValueMember = "Id";

            lblTransactionAmount.Text = "";
            lblTransactionAmountwCost.Text = "";
            lblTransactionAmountwCost.Text = "";            
        }

        public void ResetForm()
        {
            FormHelper.ResetAllControls(this);
        }

        public void SaveTrade()
        {
            var tradeVM = GetTradeEntry();
            if (tradeVM != null)
            {
                var trade = mapper.Map<TradeVM, Trade>(tradeVM);
                var msg = tradeSvc.Add(trade);

                if (msg.HasError)
                    MessageBox.Show(msg.ErrorText, "Save Trade");
                else
                    MessageBox.Show("Trade Saved", "Save Trade");
            }
            else
                MessageBox.Show("Invalid Entry detected", "Save Trade");

        }

        private TradeVM GetTradeEntry()
        {
            try
            {
                TradeVM trade = new TradeVM()
                {
                    TickerId = ((Ticker)cmbTicker.SelectedItem).Id,
                    Ticker = (Ticker)cmbTicker.SelectedItem,
                    TradeDate = dtTradeDate.Value.Date,
                    TradeType = cmbTradeType.SelectedValue.ToString(),
                    Quantity = int.Parse(txtQuantity.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                };

                trade.OtherCostperUnit = rCostPerUnit.Checked && txtCost.Text != "" ? decimal.Parse(txtCost.Text) : (decimal?)null;
                trade.TotalOtherCost = rCostPerTrade.Checked && txtCost.Text != "" ? decimal.Parse(txtCost.Text) : (decimal?)null;
                trade.TransactionAmount = trade.Quantity * trade.UnitPrice;
                trade.TransactionAmountWithCost = trade.TransactionAmount;
                if (trade.OtherCostperUnit != null && trade.OtherCostperUnit > 0)
                {
                    trade.TotalOtherCost = trade.OtherCostperUnit * trade.Quantity;
                    trade.TransactionAmountWithCost = trade.TransactionAmount + (trade.OtherCostperUnit * trade.Quantity) ?? trade.TransactionAmount;
                }
                else if (trade.TotalOtherCost != null && trade.TotalOtherCost > 0)
                {
                    trade.OtherCostperUnit = trade.OtherCostperUnit / trade.Quantity;
                    trade.TransactionAmountWithCost = trade.TransactionAmount + trade.TotalOtherCost ?? trade.TransactionAmount;
                }
                trade.UnitPriceWithCost = trade.TransactionAmountWithCost / trade.Quantity;

                return trade;
            }
            catch (Exception ex)             
            {
                Utils.Logger.Log(ex);
            }
            return null;
        }

        private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            var trade = GetTradeEntry();
            if (trade != null)
            {
                lblTransactionAmount.Text = trade.TransactionAmount.ToString("c");
                lblTransactionAmountwCost.Text = trade.TransactionAmountWithCost.ToString("c");
                lblUnitPricewCost.Text = trade.UnitPriceWithCost.ToString("c");
            }
            else
            {
                lblTransactionAmount.Text = "";
                lblTransactionAmountwCost.Text = "";
                lblUnitPricewCost.Text = "";
            }
        }

        private void btnSaveTrade_Click(object sender, EventArgs e)
        {
            SaveTrade();
        }
    }
}
