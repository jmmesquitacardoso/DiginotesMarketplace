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
                InnerMenu inner = new InnerMenu();
                inner.ShowDialog();
                this.Close();
            }
        }

        public void UpdateQuotation(float quot)
        {
            Console.WriteLine("New Diginote Quotation: {0}", quot);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }

    }
}
