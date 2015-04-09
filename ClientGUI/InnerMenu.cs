using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class InnerMenu : Form
    {
        string Username { get; set; }

        public InnerMenu(string username)
        {
            Username = username;
            InitializeComponent();
        }

        private void InnerMenu_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm.App.Logout(Username);
            this.SetVisibleCore(false);
            this.Close();
            Application.Exit();
        }

        public void changeQuotationValue(float quot) 
        {
            quotation.Text = "" + quot;
        }

        private void buyOrdersButton_Click(object sender, EventArgs e)
        {
            float newQuotationValue = float.Parse(quot.Text);
        }
    }
}
