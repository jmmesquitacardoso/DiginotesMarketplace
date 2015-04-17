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
            ordersSellSpinner.Minimum = 0;
            purchaseOrdersSpinner.Minimum = 0;

        }

        private void InnerMenu_Load(object sender, EventArgs e)
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
            ordersSellSpinner.Value = 0;
        }

        public void notifyOrder(OrderType type, int amount, float quot)
        {
            if (type == OrderType.Purchase) 
            {
                orderNotifierLabel.Text = amount + " diginotes have been bought at a quotation of " + quot;

            }
            else
            {
                orderNotifierLabel.Text = amount + " diginotes have been sold at a quotation of " + quot;
            }
        }

        public void UpdateQuotation(float quot)
        {
            if (quot < App.Quotation)
            {
                if (App.GetSaleOrders().Count > 0)
                {
                    DisplayQuotationWarning();
                }
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

        public void UpdateBalance(float balance)
        {
            currentBalanceLabel.Text = "" + balance;
        }
        public void UpdateDiginotesCount(int count)
        {
            ordersSellSpinner.Maximum = App.DiginotesNr;
            nDiginotesLabel.Text = "" + App.DiginotesNr;
        }
    }
}
