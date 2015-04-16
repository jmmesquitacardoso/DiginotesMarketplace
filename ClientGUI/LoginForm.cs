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
        public ClientApp App { get; set; }
        public InnerMenu Inner { get; set; }

        public LoginForm()
        {
            App = new ClientApp(this);
            InitializeComponent();
            Inner = new InnerMenu(App);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (App.Login(username.Text, password.Text) == Status.Valid)
            {
                this.Hide();
                Inner.Username = App.Username;
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

        public void AskNewQuotation(float currentQuot, OrderType type)
        {
            NewQuotationDialog newQuotDialog = new NewQuotationDialog(type, currentQuot);
            newQuotDialog.App = App;
            newQuotDialog.ShowDialog();
        }

        public void NotifyOrderUpdate(OrderType type, int amount, float quot)
        {
            Inner.notifyOrder(type, amount, quot);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.App = App;
            registerForm.ShowDialog();
        }

    }
}
