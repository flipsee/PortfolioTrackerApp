namespace PortfolioTrackerApp
{
    partial class frmPortfolio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabProfitLoss = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTicker = new System.Windows.Forms.ComboBox();
            this.btnPnLSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPnLAsOfDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPnL = new System.Windows.Forms.DataGridView();
            this.tabPortfolio = new System.Windows.Forms.TabPage();
            this.dgvPortfolio = new System.Windows.Forms.DataGridView();
            this.tcPortfolioApp = new System.Windows.Forms.TabControl();
            this.tabProfitLoss.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPnL)).BeginInit();
            this.tabPortfolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).BeginInit();
            this.tcPortfolioApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProfitLoss
            // 
            this.tabProfitLoss.Controls.Add(this.groupBox1);
            this.tabProfitLoss.Controls.Add(this.dgvPnL);
            this.tabProfitLoss.Location = new System.Drawing.Point(4, 22);
            this.tabProfitLoss.Margin = new System.Windows.Forms.Padding(2);
            this.tabProfitLoss.Name = "tabProfitLoss";
            this.tabProfitLoss.Padding = new System.Windows.Forms.Padding(2);
            this.tabProfitLoss.Size = new System.Drawing.Size(776, 400);
            this.tabProfitLoss.TabIndex = 1;
            this.tabProfitLoss.Text = "P & L Report";
            this.tabProfitLoss.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTicker);
            this.groupBox1.Controls.Add(this.btnPnLSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtPnLAsOfDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cmbTicker
            // 
            this.cmbTicker.FormattingEnabled = true;
            this.cmbTicker.Location = new System.Drawing.Point(121, 18);
            this.cmbTicker.Name = "cmbTicker";
            this.cmbTicker.Size = new System.Drawing.Size(121, 21);
            this.cmbTicker.TabIndex = 5;
            // 
            // btnPnLSearch
            // 
            this.btnPnLSearch.Location = new System.Drawing.Point(602, 12);
            this.btnPnLSearch.Name = "btnPnLSearch";
            this.btnPnLSearch.Size = new System.Drawing.Size(86, 30);
            this.btnPnLSearch.TabIndex = 4;
            this.btnPnLSearch.Text = "Search";
            this.btnPnLSearch.UseVisualStyleBackColor = true;
            this.btnPnLSearch.Click += new System.EventHandler(this.btnPnLSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Report as of";
            // 
            // dtPnLAsOfDate
            // 
            this.dtPnLAsOfDate.Location = new System.Drawing.Point(380, 16);
            this.dtPnLAsOfDate.Name = "dtPnLAsOfDate";
            this.dtPnLAsOfDate.Size = new System.Drawing.Size(200, 26);
            this.dtPnLAsOfDate.TabIndex = 2; 
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticker";
            // 
            // dgvPnL
            // 
            this.dgvPnL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPnL.Location = new System.Drawing.Point(5, 60);
            this.dgvPnL.Name = "dgvPnL";
            this.dgvPnL.Size = new System.Drawing.Size(766, 322);
            this.dgvPnL.TabIndex = 0;
            // 
            // tabPortfolio
            // 
            this.tabPortfolio.Controls.Add(this.dgvPortfolio);
            this.tabPortfolio.Location = new System.Drawing.Point(4, 22);
            this.tabPortfolio.Margin = new System.Windows.Forms.Padding(2);
            this.tabPortfolio.Name = "tabPortfolio";
            this.tabPortfolio.Padding = new System.Windows.Forms.Padding(2);
            this.tabPortfolio.Size = new System.Drawing.Size(776, 400);
            this.tabPortfolio.TabIndex = 0;
            this.tabPortfolio.Text = "Trades";
            this.tabPortfolio.UseVisualStyleBackColor = true;
            // 
            // dgvPortfolio
            // 
            this.dgvPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPortfolio.Location = new System.Drawing.Point(5, 5);
            this.dgvPortfolio.MultiSelect = false;
            this.dgvPortfolio.Name = "dgvPortfolio";
            this.dgvPortfolio.Size = new System.Drawing.Size(766, 390);
            this.dgvPortfolio.TabIndex = 2;
            // 
            // tcPortfolioApp
            // 
            this.tcPortfolioApp.Controls.Add(this.tabPortfolio);
            this.tcPortfolioApp.Controls.Add(this.tabProfitLoss);
            this.tcPortfolioApp.Location = new System.Drawing.Point(8, 8);
            this.tcPortfolioApp.Margin = new System.Windows.Forms.Padding(2);
            this.tcPortfolioApp.Name = "tcPortfolioApp";
            this.tcPortfolioApp.SelectedIndex = 0;
            this.tcPortfolioApp.Size = new System.Drawing.Size(784, 426);
            this.tcPortfolioApp.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tcPortfolioApp.TabIndex = 0;
            // 
            // frmPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.tcPortfolioApp);
            this.Name = "frmPortfolio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Porfolio App";
            this.tabProfitLoss.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPnL)).EndInit();
            this.tabPortfolio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortfolio)).EndInit();
            this.tcPortfolioApp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabProfitLoss;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTicker;
        private System.Windows.Forms.Button btnPnLSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPnLAsOfDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPnL;
        private System.Windows.Forms.TabPage tabPortfolio;
        private System.Windows.Forms.DataGridView dgvPortfolio;
        private System.Windows.Forms.TabControl tcPortfolioApp;
    }
}

