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
using Client;

namespace ClientGUI
{
    public partial class InnerMenu : Form, ClientInterface
    {
        public ClientApp App { get; set; }

        public InnerMenu()
        {
            App = new ClientApp(this);
            InitializeComponent();
            if (App.Username == null)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.App = App;
                loginForm.ShowDialog();
            }
            currentBalanceLabel.Text = "" + App.Balance;
            nDiginotesLabel.Text = "" + App.DiginotesNr;
            ordersSellSpinner.Minimum = 0;
            ordersSellSpinner.Maximum = App.DiginotesNr;

        }

        private void InnerMenu_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            App.Logout();
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
            App.MakePurchaseOrder(nOrders);
            purchaseOrdersSpinner.Value = 0;
            ordersSellSpinner.Maximum = App.DiginotesNr;
            nDiginotesLabel.Text = "" + App.DiginotesNr;
            currentBalanceLabel.Text = "" + App.Balance;
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
            App.MakeSaleOrder(nOrders);
            currentBalanceLabel.Text = "" + App.Balance;
        }

        private void quot_TextChanged(object sender, EventArgs e)
        {
        }

        public void notifyOrder(OrderType type, int amount, float quot)
        {
            if (type == OrderType.Purchase) 
            {
                orderNotifierLabel.Text = amount + " diginotes have been bought at a quotation of " + quot;
                ordersSellSpinner.Maximum = App.DiginotesNr;
                nDiginotesLabel.Text = "" + App.DiginotesNr;

            }
            else
            {
                orderNotifierLabel.Text = amount + " diginotes have been sold at a quotation of " + quot;
                ordersSellSpinner.Maximum = App.DiginotesNr;
                nDiginotesLabel.Text = "" + App.DiginotesNr;
            }
        }

        public void UpdateQuotation(float quot)
        {
            if (quot < App.Quotation)
            {
                DisplayQuotationWarning();
            }
            ChangeQuotationValue(quot);
        }

        public void AskNewQuotation(float currentQuot, OrderType type)
        {
            NewQuotationDialog newQuotDialog = new NewQuotationDialog(type, currentQuot);
            newQuotDialog.App = App;
            newQuotDialog.ShowDialog();
        }

        public void NotifyOrderUpdate(OrderType type, int amount, float quot)
        {
            notifyOrder(type, amount, quot);
        }

        private void purchaseOrdersSpinner_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
