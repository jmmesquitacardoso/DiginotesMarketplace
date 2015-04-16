using System;
using System.Collections;
using System.Runtime.Remoting;
using Common;

namespace Client
{
	public class ClientApp
	{
		// Attributes
		private ClientInterface parent;

		private IMarketplace SharedMarketplace { get; set; }

		private QuotationIntermediate QuotInter { get; set; }

		private OrdersIntermediate OrdInter { get; set; }

		public string Username { get; set; }

		public float Quotation { get; set; }

		// Statistics oriented
		public float Balance { get; set; }
		public int DiginotesNr { get; set; }

		public ArrayList BalanceHistory { get; set; }
		public ArrayList QuotationHistory { get; set; }
		public ArrayList DiginotesHistory { get; set; }
		public ArrayList OrderHistory { get; set; }


		public ClientApp (ClientInterface parent)
		{
			RemotingConfiguration.Configure ("Client.exe.config", false);
			SharedMarketplace = (IMarketplace)RemoteNew.New (typeof(IMarketplace));
			this.parent = parent;
            BalanceHistory = new ArrayList();
            QuotationHistory = new ArrayList();
			DiginotesHistory = new ArrayList ();
			OrderHistory = new ArrayList ();
		}

		public void Register (string name, string username, string password, int diginotes)
		{
			Console.WriteLine ("About to call Register");
			SharedMarketplace.Register (name, username, password, diginotes);
			Console.WriteLine ("Ended Register call");
		}

		public Status Login (string username, string password)
		{
			Status result = SharedMarketplace.Login (username, password);
			Console.WriteLine ("Will subscribe event");

			if (result == Status.Valid) {
				Username = username;
				Quotation = SharedMarketplace.Quotation;
				Balance = SharedMarketplace.GetUserBalance (Username);
				DiginotesNr = SharedMarketplace.GetUserDiginotes (Username).Count;
				OrderHistory = SharedMarketplace.GetPastOrders (Username);

				// Subscribe quotation's updates
				QuotInter = new QuotationIntermediate (SharedMarketplace);
				QuotInter.notifyClients += UpdateQuotation;
				parent.UpdateQuotation (SharedMarketplace.Quotation);

				// Subscribe order's updates
				OrdInter = new OrdersIntermediate (SharedMarketplace);
                OrdInter.notifyClients += NotifyOrderUpdate;
			}

			return result;
		}

		public Status Logout ()
		{
			Status result = SharedMarketplace.Logout (Username);

			if (result == Status.Valid) {
				QuotInter.notifyClients -= UpdateQuotation;
                OrdInter.notifyClients -= NotifyOrderUpdate;
                SharedMarketplace.notifyQuotClients -= QuotInter.FireQuotNotify;
                SharedMarketplace.notifyOrdClients -= OrdInter.FireOrderNotify;
			}

			return result;
		}

		public void UpdateQuotation (float quot)
		{
            Console.WriteLine("In handler: " + quot.ToString());
            parent.UpdateQuotation(quot);
			Quotation = quot;

			QuotationHistory.Add (Quotation);
			BalanceHistory.Add (Balance);
			DiginotesHistory.Add(DiginotesNr);
		}

		public ArrayList GetAvailableDiginotes ()
		{
			return SharedMarketplace.GetUserDiginotes (Username);
		}

		// Creating orders

		public bool MakeSaleOrder (int nOrders)
		{
			OrderStatus status = SharedMarketplace.AddSaleOrders (Username, nOrders);
			if (status == OrderStatus.Error) {
				return false;
			} else if (status == OrderStatus.Pending) {
                parent.AskNewQuotation(Quotation, OrderType.Sale);
                DiginotesNr = SharedMarketplace.GetUserDiginotes(Username).Count;
				//SharedMarketplace.UpdateQuotation (newQuotation);
			}
			return true;
		}

		public bool MakePurchaseOrder (int nOrders)
		{
			OrderStatus status = SharedMarketplace.AddPurchaseOrders (Username, nOrders);
			if (status == OrderStatus.Error) {
				return false;
			} else if (status == OrderStatus.Pending) {
				parent.AskNewQuotation (Quotation, OrderType.Purchase);
				//SharedMarketplace.UpdateQuotation (newQuotation);
			}
			return true;
		}

		// Reviewing orders

        public void UpdateServerQuotation(float newQuotation) 
        {
            SharedMarketplace.UpdateQuotation(newQuotation);
        }

		public ArrayList GetPurchaseOrders ()
		{
			return SharedMarketplace.GetUserPurchaseOrders (Username);
		}

		public ArrayList GetSaleOrders ()
		{
			return SharedMarketplace.GetUserSaleOrders (Username);
		}

		//Updating orders

		public bool UpdatePurchaseOrder (int id, int amount)
		{
			return SharedMarketplace.UpdatePurchaseOrder (id, amount);
		}

		public bool UpdateSaleOrder (int id, int amount)
		{
			return SharedMarketplace.UpdateSaleOrder (id, amount);
		}

		// Process order's updates
		public void NotifyOrderUpdate (string username, OrderType type, int amount, float quot)
		{
			if (Username == username) {

				Balance = SharedMarketplace.GetUserBalance (Username);

				QuotationHistory.Add (Quotation);
				BalanceHistory.Add (Balance);
				DiginotesNr = SharedMarketplace.GetUserDiginotes (Username).Count;
				DiginotesHistory.Add(DiginotesNr);
				OrderHistory.Add(new OrderRecord(type, amount, quot));

				parent.NotifyOrderUpdate (type, amount, quot);
			}
		}
	}
}
