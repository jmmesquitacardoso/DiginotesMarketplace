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

		public float PreviousQuotation { get; set; }

		public ClientApp (ClientInterface parent)
		{
			RemotingConfiguration.Configure ("Client.exe.config", false);
			SharedMarketplace = (IMarketplace)RemoteNew.New (typeof(IMarketplace));
			this.parent = parent;
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
				PreviousQuotation = SharedMarketplace.Quotation;

				// Subscribe quotation's updates
				QuotInter = new QuotationIntermediate (SharedMarketplace);
				QuotInter.notifyClients += UpdateQuotation;
				parent.UpdateQuotation (SharedMarketplace.Quotation);

				// Subscribe order's updates
				OrdInter = new QuotationIntermediate (SharedMarketplace);
				OrdInter.notifyClients += UpdateQuotation;
			}

			return result;
		}

		public Status Logout (string username)
		{
			Status result = SharedMarketplace.Logout (username);

			if (result == Status.Valid) {
				QuotInter.notifyClients -= UpdateQuotation;
				OrdInter.notifyClients -= UpdateQuotation;
			}

			return result;
		}

		public void UpdateQuotation (float quot)
		{
			parent.UpdateQuotation (quot);
		}

		public int GetAvailableDiginotes ()
		{
			return SharedMarketplace.GetUserDiginotes (Username);
		}

		// Creating orders

		public void MakeSaleOrder (int nOrders)
		{
			SharedMarketplace.addSaleOrders (Username, nOrders);
		}

		public void MakePurchaseOrder (int nOrders)
		{
			SharedMarketplace.addPurchaseOrders (Username, nOrders);
		}

		// Reviewing orders

		public ArrayList GetPurchaseOrders ()
		{
			return SharedMarketplace.GetUserPurchaseOrders (User);
		}

		public ArrayList GetSaleOrders ()
		{
			return SharedMarketplace.GetUserSaleOrders (User);
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
				parent.NotifyOrderUpdate (type, amount, quot);
			}
		}
	}
}
