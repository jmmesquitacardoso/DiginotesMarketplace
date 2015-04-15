namespace ClientGUI
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Login = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Login);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(35, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 220);
            this.panel1.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(113, 109);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(116, 25);
            this.Login.TabIndex = 4;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(113, 73);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(116, 20);
            this.password.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(113, 31);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(116, 20);
            this.username.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(337, 109);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(148, 61);
            this.registerButton.TabIndex = 1;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.35F);
            this.errorLabel.Location = new System.Drawing.Point(334, 36);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 25);
            this.errorLabel.TabIndex = 2;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 271);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label errorLabel;
    }
}