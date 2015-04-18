namespace ClientGUI
{
    partial class UpdateSaleOrders
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
            this.saleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.diginotesNumberLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newNumberTextBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale orders";
            // 
            // saleComboBox
            // 
            this.saleComboBox.FormattingEnabled = true;
            this.saleComboBox.Location = new System.Drawing.Point(100, 32);
            this.saleComboBox.Name = "saleComboBox";
            this.saleComboBox.Size = new System.Drawing.Size(182, 21);
            this.saleComboBox.TabIndex = 1;
            this.saleComboBox.SelectedIndexChanged += new System.EventHandler(this.saleComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current order diginotes number:";
            // 
            // diginotesNumberLabel
            // 
            this.diginotesNumberLabel.AutoSize = true;
            this.diginotesNumberLabel.Location = new System.Drawing.Point(181, 82);
            this.diginotesNumberLabel.Name = "diginotesNumberLabel";
            this.diginotesNumberLabel.Size = new System.Drawing.Size(0, 13);
            this.diginotesNumberLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "New diginotes number value:";
            // 
            // newNumberTextBox
            // 
            this.newNumberTextBox.Location = new System.Drawing.Point(171, 137);
            this.newNumberTextBox.Name = "newNumberTextBox";
            this.newNumberTextBox.Size = new System.Drawing.Size(151, 20);
            this.newNumberTextBox.TabIndex = 5;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(100, 204);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(160, 37);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update!";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // UpdateSaleOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 268);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.newNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.diginotesNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saleComboBox);
            this.Controls.Add(this.label1);
            this.Name = "UpdateSaleOrders";
            this.Text = "UpdateSaleOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox saleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label diginotesNumberLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newNumberTextBox;
        private System.Windows.Forms.Button updateButton;
    }
}