﻿namespace ClientGUI
{
    partial class UpdatePurchaseOrders
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
            this.purchaseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.diginotesNumberLabel = new System.Windows.Forms.Label();
            this.newNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // purchaseComboBox
            // 
            this.purchaseComboBox.FormattingEnabled = true;
            this.purchaseComboBox.Location = new System.Drawing.Point(106, 31);
            this.purchaseComboBox.Name = "purchaseComboBox";
            this.purchaseComboBox.Size = new System.Drawing.Size(189, 21);
            this.purchaseComboBox.TabIndex = 0;
            this.purchaseComboBox.SelectedIndexChanged += new System.EventHandler(this.purchaseComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Purchase orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current order diginotes number:";
            // 
            // diginotesNumberLabel
            // 
            this.diginotesNumberLabel.AutoSize = true;
            this.diginotesNumberLabel.Location = new System.Drawing.Point(173, 98);
            this.diginotesNumberLabel.Name = "diginotesNumberLabel";
            this.diginotesNumberLabel.Size = new System.Drawing.Size(0, 13);
            this.diginotesNumberLabel.TabIndex = 3;
            // 
            // newNumberTextBox
            // 
            this.newNumberTextBox.Location = new System.Drawing.Point(163, 162);
            this.newNumberTextBox.Name = "newNumberTextBox";
            this.newNumberTextBox.Size = new System.Drawing.Size(162, 20);
            this.newNumberTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New diginotes number value:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(106, 236);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(196, 39);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update!";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // UpdatePurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 297);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newNumberTextBox);
            this.Controls.Add(this.diginotesNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.purchaseComboBox);
            this.Name = "UpdatePurchaseOrders";
            this.Text = "UpdatePurchaseOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox purchaseComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label diginotesNumberLabel;
        private System.Windows.Forms.TextBox newNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button updateButton;
    }
}