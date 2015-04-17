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
using System.Threading;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace ClientGUI
{
    public partial class InnerMenu : Form, ClientInterface
    {
        public ClientApp App { get; set; }

        LineSeries QuotationLine { get; set; }

        Plot QuotationPlot { get; set; }

        LineSeries BalanceLine { get; set; }

        Plot  BalancePlot { get; set; }

        int Counter { get; set; }

        const string TrackerFormatString = "{0} : {4:0.0}€"; 

        public InnerMenu()
        {
            InitializeComponent();
            QuotationPlot = new OxyPlot.WindowsForms.Plot();
            QuotationPlot.Model = new PlotModel { Title = "Quotation Evolution" };
            QuotationLine = new LineSeries { Title = "Quotation", LineLegendPosition = LineLegendPosition.End, TrackerFormatString = TrackerFormatString };
            QuotationPlot.Model.Series.Add(QuotationLine);
            quotationGraphContainer.Controls.Add(QuotationPlot);

            BalancePlot = new OxyPlot.WindowsForms.Plot();
            BalancePlot.Model = new PlotModel { Title = "Balance Evolution" };
            BalanceLine = new LineSeries { Title = "Quotation", LineLegendPosition = LineLegendPosition.End, TrackerFormatString = TrackerFormatString };
            BalancePlot.Model.Series.Add(BalanceLine);
            balanceGraphPanel.Controls.Add(BalancePlot);

            App = new ClientApp(this);

            if (App.Username == null)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.App = App;
                loginForm.ShowDialog();
            }

            ordersSellSpinner.Minimum = 0;
            purchaseOrdersSpinner.Minimum = 0;
            Counter = 0;
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

        public void RemoveQuotationWarning()
        {
            Thread.Sleep(60000);
            warningLabel.Text = "";
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
                else
                {
                    new Thread(RemoveQuotationWarning).Start();
                }
            }
            QuotationLine.Points.Add(new DataPoint((double)Counter, (double)quot));
            BalanceLine.Points.Add(new DataPoint(Counter, App.Balance));
            Counter++;
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
            QuotationLine.Points.Add(new DataPoint(Counter, App.Quotation));
            BalanceLine.Points.Add(new DataPoint(Counter, balance));

        }
        public void UpdateDiginotesCount(int count)
        {
            ordersSellSpinner.Maximum = App.DiginotesNr;
            nDiginotesLabel.Text = "" + App.DiginotesNr;
        }
    }
}
