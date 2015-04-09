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
	public event QuotationNotifier notifyClients;

	private void UpdateCotation (float quot)
	{
		this.quot = quot;
		if (notifyClients != null) {
			Delegate[] invkList = notifyClients.GetInvocationList ();

			foreach (QuotationNotifier handler in invkList) {
				Console.WriteLine ("[Entities]: Event triggered: invoking handler");
				object[] pars = { handler, quot };
				new Thread (TriggerQuotEvent).Start (pars);
			}
		}
	}

	void TriggerQuotEvent(object pars) {
		QuotationNotifier handler = (QuotationNotifier)((object[])pars)[0];
		float quot = (float)((object[])pars)[1];
		try {
			handler(quot);
		}
		catch (Exception) {
			Console.WriteLine("[TriggerEvent]: Exception");
			notifyClients -= handler;
		}
	}

	// Sales
	// TODO

    public void addPurchaseOrders(string username, int nOrders)
    {
        Database.Instance.AddPurchaseOrder(new Order(OrderType.Purchase,Database.Instance.GetUserByUsername(username), nOrders));
    }

	// Purchases
	// TODO

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

		for (int i = 0; i < diginotes; i++)
		{
			Diginote diginote = new Diginote (username);
			diginotesList.Add (diginote);
		}
		Database.Instance.AddDiginotesToUser (username, diginotesList);

		Console.WriteLine ("\tInitial diginotes budget: " + Database.Instance.GetUserDiginotes(username).Count);

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
		User user = Database.Instance.GetUserByUsername(username);
		usersLoggedIn.Add (username, user);

		return Status.Valid;
	}

	public Status Logout (string username)
	{
		Console.WriteLine ("Logout Server side: " + username);
		if (! usersLoggedIn.Contains (username)) {
			return Status.Invalid;
		}
		usersLoggedIn.Remove (username);
		Console.WriteLine ("\tLogged out");
		return Status.Valid;
	}

}