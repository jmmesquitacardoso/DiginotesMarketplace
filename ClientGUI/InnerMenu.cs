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
        public string Username { get; set; }

        public InnerMenu()
        {
            InitializeComponent();
        }

        private void InnerMenu_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm.App.Logout(Username);
            this.SetVisibleCore(false);
            this.Close();
            Application.Exit();
        }

        public void ChangeQuotationValue(float quot) 
        {
            quotation.Text = "" + quot;
        }

        public void DisplayQuotationWarning () {
            warningLabel.Text = "New quotation is lower!";
        }

        private void buyOrdersButton_Click(object sender, EventArgs e)
        {
            float newQuotationValue = float.Parse(quot.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            Application.Exit();
        }
    }
}
