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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (App.Login(username.Text, password.Text) == Status.Valid)
            {
                Inner = new InnerMenu();
                Inner.ShowDialog();
                this.SetVisibleCore(false);
                this.Close();
            }
            else
            {
                errorLabel.Text = "Error logging in!";
                errorLabel.ForeColor = System.Drawing.Color.Red;
            }

        }

        public void UpdateQuotation(float quot)
        {
            Inner.changeQuotationValue(quot);
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
