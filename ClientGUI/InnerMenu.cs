using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace ClientGUI
{
    public partial class InnerMenu : Form
    {
        public string Username { get; set; }

        public InnerMenu()
        {
            InitializeComponent();
            ordersSellSpinner.Maximum = LoginForm.App.GetSaleOrders().Count;
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
            int nOrders = Decimal.ToInt32(purchaseOrdersSpinner.Value);
            LoginForm.App.MakePurchaseOrder(nOrders);
            ordersSellSpinner.Maximum = LoginForm.App.GetSaleOrders().Count;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            this.SetVisibleCore(false);
            this.Close();
            Application.Exit();
        }

        private void sellOrdersButton_Click(object sender, EventArgs e)
        {
            int nOrders = Decimal.ToInt32(ordersSellSpinner.Value);
            LoginForm.App.MakeSaleOrder(nOrders);
        }

        private void quot_TextChanged(object sender, EventArgs e)
        {
        }

        public void notifyOrder(OrderType type, int amount, float quot)
        {
            if (type == OrderType.Purchase) 
            {
                orderNotifierLabel.Text = amount + " diginotes have been sold at a quotation of " + quot;
            }
            else
            {
                orderNotifierLabel.Text = amount + " diginotes have been bought at a quotation of " + quot;
            }
        }
    }
}
