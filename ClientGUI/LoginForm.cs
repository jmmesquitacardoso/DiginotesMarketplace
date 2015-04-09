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

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (RegisterForm.App.Login(name.Text, username.Text, password.Text) == Status.Valid)
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

    }
}
