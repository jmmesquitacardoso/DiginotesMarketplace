using System;
using System.Collections;
using Common;
using System.Threading;

public class Marketplace : MarshalByRefObject, IMarketplace
{
	// Members
	private Hashtable usersLoggedIn;
	private float quot;

	// Events

	// Quotation update
	public event QuotationNotifier notifyQuotClients;

	private void UpdateCotation (float quot)
	{
		this.quot = quot;
		if (notifyQuotClients != null) {
			Delegate[] invkList = notifyQuotClients.GetInvocationList ();

			foreach (QuotationNotifier handler in invkList) {
				Console.WriteLine ("[Entities]: Event triggered: invoking handler");
				object[] pars = { handler, quot };
				new Thread (TriggerQuotEvent).Start (pars);
			}
		}
	}

	private void TriggerQuotEvent (object pars)
	{
		QuotationNotifier handler = (QuotationNotifier)((object[])pars) [0];
		float quot = (float)((object[])pars) [1];
		try {
			handler (quot);
		} catch (Exception) {
			Console.WriteLine ("[TriggerEvent]: Exception");
			notifyQuotClients -= handler;
		}
	}

	// Orders update
	public event OrdersNotifier notifyOrdClients;

	private void NotifyOrdersDispatch (string username, OrderType type, int amount)
	{
		if (notifyOrdClients != null) {
			Delegate[] invkList = notifyOrdClients.GetInvocationList ();

			foreach (OrdersNotifier handler in invkList) {
				Console.WriteLine ("[Entities]: Event triggered: invoking handler");
				object[] pars = { handler, username, type, amount, quot };
				new Thread (TriggerQuotEvent).Start (pars);
			}
		}
	}

	private void TriggerOrdEvent (object pars)
	{
		QuotationNotifier handler = (OrdersNotifier)((object[])pars) [0];
		string username = (string)((object[])pars) [1];
		OrderType type = (OrderType)((object[])pars) [2];
		int amount = (int)((object[])pars) [3];
		float quot = (float)((object[])pars) [4];
		try {
			handler (username, type, amount, quot);
		} catch (Exception) {
			Console.WriteLine ("[TriggerEvent]: Exception");
			notifyOrdClients -= handler;
		}
	}

	// Properties
	public float Quotation {
		get {
			return quot;
		}
	}
        
	// Constructor
	public Marketplace ()
	{
		usersLoggedIn = new Hashtable ();
	}

	// Methods
	public Status Register (string name, string username, string password, int diginotes)
	{
		Console.WriteLine ("Register Server side");

		User user = new User (name, username, password);
		Console.WriteLine ("\tNew User: " + username);

		if (Database.Instance.AddUser (user) == Status.Invalid) {
			return Status.Invalid;
		}

		ArrayList diginotesList = new ArrayList ();

		for (int i = 0; i < diginotes; i++) {
			Diginote diginote = new Diginote (username);
			diginotesList.Add (diginote);
		}
		Database.Instance.AddDiginotesToUser (username, diginotesList);

		Console.WriteLine ("\tInitial diginotes budget: " + Database.Instance.GetUserDiginotes (username).Count);

		return Status.Valid;
	}

	public Status Login (string username, string password)
	{
		Console.WriteLine ("Login Server side: " + username);
		if (!Database.Instance.Users.Contains (username) || !String.Equals (Database.Instance.GetUserByUsername (username).Password, password)) {
			Console.WriteLine ("\tLogin invalid");
			return Status.Invalid;
		}

		Console.WriteLine ("\tLogin valid");
		User user = Database.Instance.GetUserByUsername (username);
		usersLoggedIn.Add (username, user);

		return Status.Valid;
	}

	public Status Logout (string username)
	{
		Console.WriteLine ("Logout Server side: " + username);
		if (!usersLoggedIn.Contains (username)) {
			return Status.Invalid;
		}
		usersLoggedIn.Remove (username);
		Console.WriteLine ("\tLogged out");
		return Status.Valid;
	}

	public int GetUserDiginotes (string username)
	{
		return Database.Instance.GetUserDiginotes (username);
	}

	// Sales

	public Status addSaleOrders (string username, int nOrders)
	{
		if (usersLoggedIn.Contains (username)) {
			ArrayList diginotes = Database.Instance.RemoveDiginotesFromUser (username, nOrders);
			if (diginotes != null) {
				SaleOrder order = new SaleOrder (username, nOrders);
				order.AddDiginotes (diginotes);
				Database.Instance.AddSaleOrder (order);
				return Status.Valid;
			}
		}
		return Status.Invalid;
	}

	public ArrayList GetUserSaleOrders (string username)
	{
		return Database.Instance.GetUserSaleOrders (username);
	}

	public bool UpdateSaleOrder (int id, int amount)
	{
		return Database.Instance.UpdateSaleOrder (id, amount);
	}

	// Purchases

	public Status AddPurchaseOrders (string username, int nOrders)
	{
		if (usersLoggedIn.Contains (username)) {
			PurchaseOrder order = new PurchaseOrder (username, nOrders);
			Database.Instance.AddPurchaseOrder (order);
			return Status.Valid;
		}

		return Status.Invalid;
	}

	public ArrayList GetUserPurchaseOrders (string username)
	{
		return Database.Instance.GetUserPurchaseOrders (username);
	}

	public bool UpdatePurchaseOrder (int id, int amount)
	{
		return Database.Instance.UpdatePurchaseOrder (id, amount);
	}

	// Dispatch orders
	private void DispatchOrders ()
	{
		PurchaseOrder currentPurchase;
		while ((currentPurchase = Database.Instance.GetOldestPurchaseOrder ()) != null
			&& Database.Instance.GetDiginotesOnSaleCount() > 0) {

			int desiredDiginotes = currentPurchase.Amount;
			ArrayList diginotes = Database.Instance.RemoveFromOldestSale (desiredDiginotes);

			int diginotesDispatched = desiredDiginotes - diginotes.Count;
			string sellerUsername = ((SaleOrder)diginotes [0]).User;
			string buyerUsername = currentPurchase.User;

			// Change owner
			for (int i = 0, l = diginotes.Count; i < l; i++) {
				((Diginote)diginotes [i]).Owner = buyerUsername;
			}
			Database.Instance.AddDiginotesToUser (buyerUsername, diginotes);

			// fire events
			NotifyOrdersDispatch (sellerUsername, OrderType.Sale, diginotesDispatched);
			NotifyOrdersDispatch (buyerUsername, OrderType.Purchase, diginotesDispatched);

			Database.Instance.UpdateOldestPurchaseOrder (diginotesDispatched);
		}
	}

	// Change quotation
	// TODO: Can increment? Can decrement? Increment Decrement
}