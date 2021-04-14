namespace PortfolioTrackerApp
{
    partial class frmAddTrade
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.rCostPerTrade = new System.Windows.Forms.RadioButton();
            this.rCostPerUnit = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbTicker = new System.Windows.Forms.ComboBox();
            this.dtTradeDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTradeType = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUnitPricewCost = new System.Windows.Forms.Label();
            this.lblTransactionAmountwCost = new System.Windows.Forms.Label();
            this.lblTransactionAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveTrade = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ticker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trade Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trade Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Unit Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.rCostPerTrade);
            this.groupBox1.Controls.Add(this.rCostPerUnit);
            this.groupBox1.Location = new System.Drawing.Point(12, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 102);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(63, 55);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 26);
            this.txtCost.TabIndex = 12;
            this.txtCost.Click += new System.EventHandler(this.CalculateTotal);
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            this.txtCost.Leave += new System.EventHandler(this.CalculateTotal);
            // 
            // rCostPerTrade
            // 
            this.rCostPerTrade.AutoSize = true;
            this.rCostPerTrade.Location = new System.Drawing.Point(112, 25);
            this.rCostPerTrade.Name = "rCostPerTrade";
            this.rCostPerTrade.Size = new System.Drawing.Size(143, 24);
            this.rCostPerTrade.TabIndex = 11;
            this.rCostPerTrade.TabStop = true;
            this.rCostPerTrade.Text = "Total / Per Trade";
            this.rCostPerTrade.UseVisualStyleBackColor = true;
            this.rCostPerTrade.CheckedChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // rCostPerUnit
            // 
            this.rCostPerUnit.AutoSize = true;
            this.rCostPerUnit.Location = new System.Drawing.Point(6, 25);
            this.rCostPerUnit.Name = "rCostPerUnit";
            this.rCostPerUnit.Size = new System.Drawing.Size(84, 24);
            this.rCostPerUnit.TabIndex = 10;
            this.rCostPerUnit.TabStop = true;
            this.rCostPerUnit.Text = "Per Unit";
            this.rCostPerUnit.UseVisualStyleBackColor = true;
            this.rCostPerUnit.CheckedChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.2732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.72681F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbTicker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtTradeDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTradeType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtUnitPrice, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 176);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // cmbTicker
            // 
            this.cmbTicker.FormattingEnabled = true;
            this.cmbTicker.Location = new System.Drawing.Point(106, 3);
            this.cmbTicker.Name = "cmbTicker";
            this.cmbTicker.Size = new System.Drawing.Size(200, 21);
            this.cmbTicker.TabIndex = 6;
            // 
            // dtTradeDate
            // 
            this.dtTradeDate.Location = new System.Drawing.Point(106, 38);
            this.dtTradeDate.Name = "dtTradeDate";
            this.dtTradeDate.Size = new System.Drawing.Size(200, 26);
            this.dtTradeDate.TabIndex = 7;
            // 
            // cmbTradeType
            // 
            this.cmbTradeType.FormattingEnabled = true;
            this.cmbTradeType.ItemHeight = 13;
            this.cmbTradeType.Location = new System.Drawing.Point(106, 73);
            this.cmbTradeType.Name = "cmbTradeType";
            this.cmbTradeType.Size = new System.Drawing.Size(200, 21);
            this.cmbTradeType.TabIndex = 8;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(106, 108);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 26);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInt_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.CalculateTotal);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(106, 143);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(200, 26);
            this.txtUnitPrice.TabIndex = 10;
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            this.txtUnitPrice.Leave += new System.EventHandler(this.CalculateTotal);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUnitPricewCost);
            this.groupBox2.Controls.Add(this.lblTransactionAmountwCost);
            this.groupBox2.Controls.Add(this.lblTransactionAmount);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // lblUnitPricewCost
            // 
            this.lblUnitPricewCost.AutoSize = true;
            this.lblUnitPricewCost.Location = new System.Drawing.Point(247, 99);
            this.lblUnitPricewCost.Name = "lblUnitPricewCost";
            this.lblUnitPricewCost.Size = new System.Drawing.Size(132, 20);
            this.lblUnitPricewCost.TabIndex = 11;
            this.lblUnitPricewCost.Text = "lblUnitPricewCost";
            // 
            // lblTransactionAmountwCost
            // 
            this.lblTransactionAmountwCost.AutoSize = true;
            this.lblTransactionAmountwCost.Location = new System.Drawing.Point(247, 65);
            this.lblTransactionAmountwCost.Name = "lblTransactionAmountwCost";
            this.lblTransactionAmountwCost.Size = new System.Drawing.Size(207, 20);
            this.lblTransactionAmountwCost.TabIndex = 10;
            this.lblTransactionAmountwCost.Text = "lblTransactionAmountwCost";
            // 
            // lblTransactionAmount
            // 
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(246, 33);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(163, 20);
            this.lblTransactionAmount.TabIndex = 9;
            this.lblTransactionAmount.Text = "lblTransactionAmount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Unit Price with Cost";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Transaction Amount with Cost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Transaction Amount";
            // 
            // btnSaveTrade
            // 
            this.btnSaveTrade.Location = new System.Drawing.Point(641, 367);
            this.btnSaveTrade.Name = "btnSaveTrade";
            this.btnSaveTrade.Size = new System.Drawing.Size(112, 38);
            this.btnSaveTrade.TabIndex = 11;
            this.btnSaveTrade.Text = "Save Trade";
            this.btnSaveTrade.UseVisualStyleBackColor = true;
            this.btnSaveTrade.Click += new System.EventHandler(this.btnSaveTrade_Click);
            // 
            // frmAddTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveTrade);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddTrade";
            this.Text = "frmAddPortfolio";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.RadioButton rCostPerTrade;
        private System.Windows.Forms.RadioButton rCostPerUnit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbTicker;
        private System.Windows.Forms.DateTimePicker dtTradeDate;
        private System.Windows.Forms.ComboBox cmbTradeType;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTransactionAmount;
        private System.Windows.Forms.Label lblUnitPricewCost;
        private System.Windows.Forms.Label lblTransactionAmountwCost;
        private System.Windows.Forms.Button btnSaveTrade;
    }
}