namespace ClientGUI
{
    partial class NewQuotationDialog
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
            this.quotationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmQuotation = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // quotationTextBox
            // 
            this.quotationTextBox.Location = new System.Drawing.Point(91, 46);
            this.quotationTextBox.Name = "quotationTextBox";
            this.quotationTextBox.Size = new System.Drawing.Size(198, 20);
            this.quotationTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Quotation";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // confirmQuotation
            // 
            this.confirmQuotation.Location = new System.Drawing.Point(91, 81);
            this.confirmQuotation.Name = "confirmQuotation";
            this.confirmQuotation.Size = new System.Drawing.Size(198, 41);
            this.confirmQuotation.TabIndex = 2;
            this.confirmQuotation.Text = "Confirm New Quotation";
            this.confirmQuotation.UseVisualStyleBackColor = true;
            this.confirmQuotation.Click += new System.EventHandler(this.confirmQuotation_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.35F);
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(30, 155);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 17);
            this.errorLabel.TabIndex = 3;
            // 
            // NewQuotationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 220);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.confirmQuotation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quotationTextBox);
            this.Name = "NewQuotationDialog";
            this.Text = "NewQuotationDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox quotationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmQuotation;
        private System.Windows.Forms.Label errorLabel;
    }
}