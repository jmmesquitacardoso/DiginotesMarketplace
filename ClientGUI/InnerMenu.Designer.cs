namespace ClientGUI
{
    partial class InnerMenu
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.buyOrdersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sellOrdersButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.quotation = new System.Windows.Forms.Label();
            this.ordersSellSpinner = new System.Windows.Forms.NumericUpDown();
            this.warningLabel = new System.Windows.Forms.Label();
            this.purchaseOrdersSpinner = new System.Windows.Forms.NumericUpDown();
            this.orderNotifierLabel = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.currentBalanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ordersSellSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrdersSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(516, 196);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(150, 48);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // buyOrdersButton
            // 
            this.buyOrdersButton.Location = new System.Drawing.Point(177, 102);
            this.buyOrdersButton.Name = "buyOrdersButton";
            this.buyOrdersButton.Size = new System.Drawing.Size(174, 28);
            this.buyOrdersButton.TabIndex = 2;
            this.buyOrdersButton.Text = "Buy Orders";
            this.buyOrdersButton.UseVisualStyleBackColor = true;
            this.buyOrdersButton.Click += new System.EventHandler(this.buyOrdersButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of orders to buy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of orders to sell";
            // 
            // sellOrdersButton
            // 
            this.sellOrdersButton.Location = new System.Drawing.Point(177, 238);
            this.sellOrdersButton.Name = "sellOrdersButton";
            this.sellOrdersButton.Size = new System.Drawing.Size(174, 28);
            this.sellOrdersButton.TabIndex = 7;
            this.sellOrdersButton.Text = "Sell Orders";
            this.sellOrdersButton.UseVisualStyleBackColor = true;
            this.sellOrdersButton.Click += new System.EventHandler(this.sellOrdersButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current Quotation:";
            // 
            // quotation
            // 
            this.quotation.AutoSize = true;
            this.quotation.Location = new System.Drawing.Point(585, 58);
            this.quotation.Name = "quotation";
            this.quotation.Size = new System.Drawing.Size(0, 13);
            this.quotation.TabIndex = 12;
            // 
            // ordersSellSpinner
            // 
            this.ordersSellSpinner.Location = new System.Drawing.Point(177, 196);
            this.ordersSellSpinner.Name = "ordersSellSpinner";
            this.ordersSellSpinner.Size = new System.Drawing.Size(174, 20);
            this.ordersSellSpinner.TabIndex = 13;
            this.ordersSellSpinner.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(475, 101);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 13);
            this.warningLabel.TabIndex = 14;
            // 
            // purchaseOrdersSpinner
            // 
            this.purchaseOrdersSpinner.Location = new System.Drawing.Point(177, 60);
            this.purchaseOrdersSpinner.Name = "purchaseOrdersSpinner";
            this.purchaseOrdersSpinner.Size = new System.Drawing.Size(171, 20);
            this.purchaseOrdersSpinner.TabIndex = 15;
            this.purchaseOrdersSpinner.ValueChanged += new System.EventHandler(this.purchaseOrdersSpinner_ValueChanged);
            // 
            // orderNotifierLabel
            // 
            this.orderNotifierLabel.AutoSize = true;
            this.orderNotifierLabel.Location = new System.Drawing.Point(376, 358);
            this.orderNotifierLabel.Name = "orderNotifierLabel";
            this.orderNotifierLabel.Size = new System.Drawing.Size(0, 13);
            this.orderNotifierLabel.TabIndex = 16;
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(471, 35);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(86, 13);
            this.labelx.TabIndex = 17;
            this.labelx.Text = "Current Balance:";
            // 
            // currentBalanceLabel
            // 
            this.currentBalanceLabel.AutoSize = true;
            this.currentBalanceLabel.Location = new System.Drawing.Point(564, 35);
            this.currentBalanceLabel.Name = "currentBalanceLabel";
            this.currentBalanceLabel.Size = new System.Drawing.Size(0, 13);
            this.currentBalanceLabel.TabIndex = 18;
            this.currentBalanceLabel.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // InnerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 568);
            this.Controls.Add(this.currentBalanceLabel);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.orderNotifierLabel);
            this.Controls.Add(this.purchaseOrdersSpinner);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.ordersSellSpinner);
            this.Controls.Add(this.quotation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sellOrdersButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buyOrdersButton);
            this.Controls.Add(this.logoutButton);
            this.Name = "InnerMenu";
            this.Text = "Diginotes Marketplace";
            this.Load += new System.EventHandler(this.InnerMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersSellSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrdersSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button buyOrdersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sellOrdersButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label quotation;
        private System.Windows.Forms.NumericUpDown ordersSellSpinner;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.NumericUpDown purchaseOrdersSpinner;
        private System.Windows.Forms.Label orderNotifierLabel;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.Label currentBalanceLabel;
    }
}