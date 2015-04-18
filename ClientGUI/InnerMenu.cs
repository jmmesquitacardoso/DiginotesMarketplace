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
using System.Collections;
using OxyPlot.Axes;

namespace ClientGUI
{
	public partial class InnerMenu : Form, ClientInterface
	{
		public ClientApp App { get; set; }

		LineSeries QuotationLine { get; set; }

		PlotView QuotationPlot { get; set; }

		LineSeries BalanceLine { get; set; }

		PlotView  BalancePlot { get; set; }

		int Counter { get; set; }

		const string TrackerFormatString = "{0} : {4:0.0}€";

		public InnerMenu ()
		{
			InitializeComponent ();
			initPlots ();

			App = new ClientApp (this);

			if (App.Username == null) {
				LoginForm loginForm = new LoginForm ();
				loginForm.App = App;
				loginForm.ShowDialog ();
			}

			ordersSellSpinner.Minimum = 0;
			purchaseOrdersSpinner.Minimum = 0;
			Counter = 0;
		}

		private void initPlots() {

			QuotationPlot = new OxyPlot.WindowsForms.PlotView ();
			QuotationPlot.Dock = System.Windows.Forms.DockStyle.Fill;
			QuotationPlot.Location = new System.Drawing.Point (0, 0);
			QuotationPlot.Name = "plot1";
			QuotationPlot.PanCursor = System.Windows.Forms.Cursors.Hand;
			QuotationPlot.Size = new System.Drawing.Size (484, 312);
			QuotationPlot.TabIndex = 0;
			QuotationPlot.Text = "plot1";
			QuotationPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			QuotationPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			QuotationPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			var quotModel = new PlotModel { Title = "Quotation Evolution" };

			quotModel.Axes.Add (new LinearAxis {
				Key = "xAxis",
				Position = AxisPosition.Bottom,
				Maximum = 10,
				Title = "Actions"
			});

			quotModel.Axes.Add (new LinearAxis {
				Key = "yAxis",
				Position = AxisPosition.Left,
				Title = "Quotation"
			});

			QuotationPlot.Model = quotModel;

			quotationGraphContainer.Controls.Add (QuotationPlot);



			BalancePlot = new OxyPlot.WindowsForms.PlotView ();
			BalancePlot.Dock = System.Windows.Forms.DockStyle.Fill;
			BalancePlot.Location = new System.Drawing.Point (0, 0);
			BalancePlot.Name = "plot2";
			BalancePlot.PanCursor = System.Windows.Forms.Cursors.Hand;
			BalancePlot.Size = new System.Drawing.Size (484, 312);
			BalancePlot.TabIndex = 0;
			BalancePlot.Text = "plot2";
			BalancePlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			BalancePlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			BalancePlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			var balanceModel = new PlotModel { Title = "Balance Evolution" };

			balanceModel.Axes.Add (new LinearAxis {
				Key = "xAxis",
				Position = AxisPosition.Bottom,
				Maximum = 10,
				Title = "Actions"
			});

			balanceModel.Axes.Add (new LinearAxis {
				Key = "yAxis",
				Position = AxisPosition.Left,
				Title = "Balance"
			});

			BalancePlot.Model = balanceModel;

			balanceGraphPanel.Controls.Add (BalancePlot);
		}

		private void InnerMenu_Load (object sender, EventArgs e)
		{
		}

		private void logoutButton_Click (object sender, EventArgs e)
		{
			App.Logout ();
			this.SetVisibleCore (false);
			this.Close ();
			Application.Exit ();
		}

		public void ChangeQuotationValue (float quot)
		{
			quotation.Text = "" + quot;
		}

		public void RemoveQuotationWarning ()
		{
			Thread.Sleep (60000);
			warningLabel.Text = "";
		}

		public void DisplayQuotationWarning ()
		{
			warningLabel.Text = "New quotation is lower!";
		}

		private void buyOrdersButton_Click (object sender, EventArgs e)
		{
			int nOrders = Decimal.ToInt32 (purchaseOrdersSpinner.Value);
			App.MakePurchaseOrder (nOrders);
			purchaseOrdersSpinner.Value = 0;
		}

		protected override void OnFormClosing (FormClosingEventArgs e)
		{
			base.OnFormClosing (e);

			this.SetVisibleCore (false);
			this.Close ();
			Application.Exit ();
		}

		private void sellOrdersButton_Click (object sender, EventArgs e)
		{
			int nOrders = Decimal.ToInt32 (ordersSellSpinner.Value);
			App.MakeSaleOrder (nOrders);
			ordersSellSpinner.Value = 0;
		}

		public void notifyOrder (OrderType type, int amount, float quot)
		{
			if (type == OrderType.Purchase) {
				orderNotifierLabel.Text = amount + " diginotes have been bought at a quotation of " + quot;

			} else {
				orderNotifierLabel.Text = amount + " diginotes have been sold at a quotation of " + quot;
			}
		}

		public void UpdateQuotation (float quot)
		{
			if (quot < App.Quotation) {
				if (App.GetSaleOrders ().Count > 0) {
					DisplayQuotationWarning ();
				} else {
					new Thread (RemoveQuotationWarning).Start ();
				}	
			}

			// Quotation
			ChangeQuotationValue (quot);
			QuotationPlot.Model.InvalidatePlot (true);

			QuotationLine = new LineSeries {YAxisKey = "yAxis"};
			ArrayList history = App.GetTenLastQuotations ();

			for (int i = 0, l = history.Count; i < l; i++) {
				QuotationLine.Points.Add (new DataPoint (i, (double)((float)history [i])));
			}

			QuotationPlot.Model.Series.Clear ();
			QuotationPlot.Model.Series.Add (QuotationLine);

			QuotationPlot.Model.InvalidatePlot (false);
			QuotationPlot.Update ();
			QuotationPlot.Refresh ();

			// Balance
			BalancePlot.Model.InvalidatePlot (true);

			BalanceLine = new LineSeries {YAxisKey = "yAxis"};
			ArrayList balHistory = App.GetTenLastQuotations ();

			for (int i = 0, l = balHistory.Count; i < l; i++) {
				BalanceLine.Points.Add (new DataPoint (i, (double)((float)balHistory [i])));
			}

			BalancePlot.Model.Series.Clear ();
			BalancePlot.Model.Series.Add (BalanceLine);

			BalancePlot.Model.InvalidatePlot (false);
			BalancePlot.Update ();
			BalancePlot.Refresh ();

			this.Refresh ();
			Counter++;
		}

		public void AskNewQuotation (float currentQuot, OrderType type)
		{
			NewQuotationDialog newQuotDialog = new NewQuotationDialog (type, currentQuot);
			newQuotDialog.App = App;
			newQuotDialog.ShowDialog ();
		}

		public void NotifyOrderUpdate (OrderType type, int amount, float quot)
		{
			notifyOrder (type, amount, quot);
		}

		public void UpdateBalance (float balance)
		{
			currentBalanceLabel.Text = "" + balance;
			// BalanceLine.Points.Add (new DataPoint (Counter, balance));

		}

		public void UpdateDiginotesCount (int count)
		{
			ordersSellSpinner.Maximum = App.DiginotesNr;
			nDiginotesLabel.Text = "" + App.DiginotesNr;
		}
	}
}
