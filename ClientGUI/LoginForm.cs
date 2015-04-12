using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using Common;

namespace ClientGUI
{
    public partial class LoginForm : Form, ClientInterface
    {
        public static ClientApp App { get; set; }
        public InnerMenu Inner { get; set; }

        public LoginForm()
        {
            App = new ClientApp(this);
            InitializeComponent();
            Inner = new InnerMenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (App.Login(username.Text, password.Text) == Status.Valid)
            {
                this.Hide();
                Inner.Username = username.Text;
                Inner.ShowDialog();
            }
            else
            {
                errorLabel.Text = "Error logging in!";
                errorLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void UpdateQuotation(float quot)
        {
            if (quot < App.Quotation)
            {
                Inner.DisplayQuotationWarning();
            }
            Inner.ChangeQuotationValue(quot);
        }

        public float AskNewQuotation()
        {
            return -1f;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

    }
}
