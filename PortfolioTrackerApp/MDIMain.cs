using Common.Contracts;
using PortfolioTrackerApp.Helper;
using System;
using System.Windows.Forms;

namespace PortfolioTrackerApp
{
    public partial class MDIMain : Form
    {
        private readonly frmAddTrade frmAddTrade;
        private readonly frmPortfolio frmPortfolio;
        private readonly DBInit db;
        private readonly IModelMapper mapper;
        public MDIMain(DBInit db, IModelMapper mapper, frmPortfolio frmPortfolio, frmAddTrade frmAddTrade)
        {
            InitializeComponent();

            this.frmPortfolio = frmPortfolio;
            this.frmAddTrade = frmAddTrade;

            ShowPortfolioForm(null,null);
        }

        private void ShowAddTradeForm(object sender, EventArgs e)
        {
            frmAddTrade.MdiParent = this; 
            frmAddTrade.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmAddTrade.Dock = DockStyle.Fill;
            frmAddTrade.ResetForm();
            frmAddTrade.Show();

            saveToolStripButton.Visible = true;
            saveToolStripMenuItem.Visible = true;
            
            if (frmPortfolio.Visible)
                frmPortfolio.Hide();
        }

        private void ShowPortfolioForm(object sender, EventArgs e)
        {
            frmPortfolio.MdiParent = this; 
            frmPortfolio.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmPortfolio.Dock = DockStyle.Fill;
            frmPortfolio.ResetForm();
            frmPortfolio.Show();

            if (frmAddTrade.Visible)
                frmAddTrade.Hide();

            saveToolStripButton.Visible = false;
            saveToolStripMenuItem.Visible = false;
        }        
        
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.frmAddTrade.SaveTrade();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frmAddTrade.SaveTrade();
        }
    }
}
