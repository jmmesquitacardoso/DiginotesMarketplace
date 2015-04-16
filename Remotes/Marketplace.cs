using System;
using System.Collections;
using Common;
using System.Threading;

public class Marketplace : MarshalByRefObject, IMarketplace
{
	// Members
	private Hashtable usersLoggedIn;
	private bool isWaiting = false;

	// Events

	// Quotation update
	public event QuotationNotifier notifyQuotClients;

	public void UpdateQuotation (float quot)
	{
		if (quot < Database.Instance.Quotation) {
			isWaiting = true;
			new Thread (DelayDispatch).Start ();
		} else {
			if (!isWaiting) {
				DispatchOrders ();
			}
		}

		Database.Instance.Quotation = quot;
		if (notifyQuotClients != null) {
			Delegate[] invkList = notifyQuotClients.GetInvocationList ();

			foreach (QuotationNotifier handler in invkList) {
				Console.WriteLine ("[Entities]: Event triggered: invoking handler");
				Console.WriteLine ("[Entities]: " + handler.Target.ToString ());
				object[] pars = { handler, quot };
				new Thread (TriggerQuotEvent).Start (pars);
			}
		}
	}

	private void DelayDispatch ()
	{
		Thread.Sleep (60000);
		DispatchOrders ();
		isWaiting = false;
	}

	private void TriggerQuotEvent (object pars)
	{
		QuotationNotifier handler = (QuotationNotifier)(((object[])pars) [0]);
		Console.WriteLine ("[TriggerQuotationEvent]: " + handler.Target.ToString ());
		float quot = (float)(((object[])pars) [1]);
		Console.WriteLine ("Quotation Server: {0}", quot);
		try {
			handler (quot);
		} catch (Exception ex) {
			Console.WriteLine ("[TriggerQuotationEvent]: Exception");
			Console.WriteLine ("Exception: {0}", ex.StackTrace);
			Console.WriteLine ("Exception: {0}", ex.ToString ());
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
				object[] pars = { handler, username, type, amount, Database.Instance.Quotation };
				new Thread (TriggerQuotEvent).Start (pars);
			}
		}
	}

	private void TriggerOrdEvent (object pars)
	{
		OrdersNotifier handler = (OrdersNotifier)((object[])pars) [0];
		string username = (string)((object[])pars) [1];
		OrderType type = (OrderType)((object[])pars) [2];
		int amount = (int)((object[])pars) [3];
		float quot = (float)((object[])pars) [4];
		try {
			handler (username, type, amount, quot);
		} catch (Exception) {
			Console.WriteLine ("[TriggerOrderEvent]: Exception");
			notifyOrdClients -= handler;
		}
	}

	// Properties
	public float Quotation {
		get {
			return Database.Instance.Quotation;
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
		if (!Database.Instance.Users.Contains (username) || !String.Equals (Database.Instance.GetUserByUsername (username).Password, password)
		    || usersLoggedIn.Contains (username)) {
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

	public ArrayList GetUserDiginotes (string username)
	{
		return Database.Instance.GetUserDiginotes (username);
	}

	// Sales

	public OrderStatus AddSaleOrders (string username, int nOrders)
	{
		if (!usersLoggedIn.Contains (username)) {
			return OrderStatus.Error;
		}

		ArrayList diginotes = Database.Instance.RemoveDiginotesFromUser (username, nOrders);
        Console.WriteLine("Diginotes length: " + diginotes.Count);
		if (diginotes == null) {
			return OrderStatus.Error;
		}
		SaleOrder order = new SaleOrder (username, nOrders);
		int id = order.Id;
		order.AddDiginotes (diginotes);
		Database.Instance.AddSaleOrder (order);

		if (!isWaiting) {
			DispatchOrders ();
		}
		if (Database.Instance.IsOrderPending (id)) {
			return OrderStatus.Pending;
		} else {
			return OrderStatus.Dispatched;
		}
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

	public OrderStatus AddPurchaseOrders (string username, int nOrders)
	{
		if (!usersLoggedIn.Contains (username)) {
			Console.WriteLine ("Not logged in!");
			return OrderStatus.Error;
		}

		Console.WriteLine ("Adding purchase orders");

		PurchaseOrder order = new PurchaseOrder (username, nOrders);
		int id = order.Id;
		Database.Instance.AddPurchaseOrder (order);

		if (!isWaiting) {
			DispatchOrders ();
		}
		if (Database.Instance.IsOrderPending (id)) {
			return OrderStatus.Pending;
		} else {
			return OrderStatus.Dispatched;
		}

	}

	public ArrayList GetUserPurchaseOrders (string username)
	{
		return Database.Instance.GetUserPurchaseOrders (username);
	}

	public bool UpdatePurchaseOrder (int id, int amount)
	{
		return Database.Instance.UpdatePurchaseOrder (id, amount);
	}

	public float GetUserBalance (string username)
	{
		return Database.Instance.GetUserBalance (username);
	}

	// Dispatch orders
	private void DispatchOrders ()
	{
		PurchaseOrder currentPurchase;
		while ((currentPurchase = Database.Instance.GetOldestPurchaseOrder ()) != null
		       && Database.Instance.GetDiginotesOnSaleCount () > 0) {

			int desiredDiginotes = currentPurchase.Amount;
			ArrayList diginotes = Database.Instance.RemoveFromOldestSale (desiredDiginotes);

			int diginotesDispatched = desiredDiginotes - diginotes.Count;
			string sellerUsername = ((Diginote)diginotes [0]).Owner;
			string buyerUsername = currentPurchase.User;

			// Change owner
			for (int i = 0, l = diginotes.Count; i < l; i++) {
				((Diginote)diginotes [i]).Owner = buyerUsername;
			}
			Database.Instance.AddDiginotesToUser (buyerUsername, diginotes);

			// update balances
			float buyerBalance = Database.Instance.GetUserBalance (buyerUsername);
			float sellerBalance = Database.Instance.GetUserBalance (sellerUsername);

			buyerBalance -= Quotation * diginotesDispatched;
			sellerBalance += Quotation * diginotesDispatched;

			Database.Instance.SetUserBalance (buyerUsername, buyerBalance);
			Database.Instance.SetUserBalance (sellerUsername, sellerBalance);

			// fire events
			NotifyOrdersDispatch (sellerUsername, OrderType.Sale, diginotesDispatched);
			NotifyOrdersDispatch (buyerUsername, OrderType.Purchase, diginotesDispatched);

			Database.Instance.AddOrderRecord (sellerUsername, OrderType.Sale, diginotesDispatched, Quotation);

			Database.Instance.UpdateOldestPurchaseOrder (diginotesDispatched);
		}
	}


	public ArrayList GetPastOrders (string username)
	{
		return Database.Instance.GetPastOrders (username);
	}
}