using System;
using System.Collections;
using Common;
using System.Threading;

public class Marketplace : MarshalByRefObject, IMarketplace
{
	// Members
	private Hashtable usersLoggedIn;
	private float quot;
	private Queue orders;
	private Queue sells;

	// Events
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
		if (Database.Instance.Users.Contains (username)) {
			return Status.Invalid;
		}
		User user = new User (name, username, password);
		Console.WriteLine ("New User");
		user.AddDiginotes (diginotes);
		Console.WriteLine ("Added Diginotes");
		Database.Instance.AddUser (username, user);
		Console.WriteLine ("Added to DB");
		return Status.Valid;
	}

	public Status Login (string name, string username, string password)
	{
		Console.WriteLine ("Login Server side");
		if (Database.Instance.Users.Contains (username) && String.Equals (Database.Instance.getUserByUsername (username).Password, password)) {
			User user = new User (name, username, password);
			usersLoggedIn.Add (username, user);
			return Status.Valid;
		}

		return Status.Invalid;
	}

	public Status Logout (string username)
	{
		Console.WriteLine ("Logout Server side");
		if (usersLoggedIn.Contains (username)) {
			usersLoggedIn.Remove (username);
			return Status.Valid;
		}
		return Status.Invalid;
	}

}