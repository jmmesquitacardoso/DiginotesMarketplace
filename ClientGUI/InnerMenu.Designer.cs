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
            this.button1 = new System.Windows.Forms.Button();
            this.buyOrdersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nOrdersBuy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nOrdersSell = new System.Windows.Forms.TextBox();
            this.sellOrdersButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.quot = new System.Windows.Forms.TextBox();
            this.changeQuotationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.quotation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // nOrdersBuy
            // 
            this.nOrdersBuy.Location = new System.Drawing.Point(177, 60);
            this.nOrdersBuy.Name = "nOrdersBuy";
            this.nOrdersBuy.Size = new System.Drawing.Size(174, 20);
            this.nOrdersBuy.TabIndex = 4;
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
            // nOrdersSell
            // 
            this.nOrdersSell.Location = new System.Drawing.Point(177, 196);
            this.nOrdersSell.Name = "nOrdersSell";
            this.nOrdersSell.Size = new System.Drawing.Size(174, 20);
            this.nOrdersSell.TabIndex = 6;
            // 
            // sellOrdersButton
            // 
            this.sellOrdersButton.Location = new System.Drawing.Point(177, 238);
            this.sellOrdersButton.Name = "sellOrdersButton";
            this.sellOrdersButton.Size = new System.Drawing.Size(174, 28);
            this.sellOrdersButton.TabIndex = 7;
            this.sellOrdersButton.Text = "Sell Orders";
            this.sellOrdersButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "New diginote quotation";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // quot
            // 
            this.quot.Location = new System.Drawing.Point(177, 321);
            this.quot.Name = "quot";
            this.quot.Size = new System.Drawing.Size(174, 20);
            this.quot.TabIndex = 9;
            // 
            // changeQuotationButton
            // 
            this.changeQuotationButton.Location = new System.Drawing.Point(177, 362);
            this.changeQuotationButton.Name = "changeQuotationButton";
            this.changeQuotationButton.Size = new System.Drawing.Size(174, 28);
            this.changeQuotationButton.TabIndex = 10;
            this.changeQuotationButton.Text = "Change Quotation";
            this.changeQuotationButton.UseVisualStyleBackColor = true;
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
            this.quotation.Size = new System.Drawing.Size(35, 13);
            this.quotation.TabIndex = 12;
            this.quotation.Text = "label5";
            // 
            // InnerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 568);
            this.Controls.Add(this.quotation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.changeQuotationButton);
            this.Controls.Add(this.quot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sellOrdersButton);
            this.Controls.Add(this.nOrdersSell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nOrdersBuy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buyOrdersButton);
            this.Controls.Add(this.button1);
            this.Name = "InnerMenu";
            this.Text = "Diginotes Marketplace";
            this.Load += new System.EventHandler(this.InnerMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buyOrdersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nOrdersBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nOrdersSell;
        private System.Windows.Forms.Button sellOrdersButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quot;
        private System.Windows.Forms.Button changeQuotationButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label quotation;
    }
}