using System;
using System.Collections;
using Shared;

public class Marketplace : MarshalByRefObject
{
	public enum Status
	{
		Valid,
		Invalid,
		SharedObjError}

	;

	// Members
	private Hashtable usersLoggedIn;
	private float quot;

	// Delegate types
	public delegate void QuotationNotifier (float quot);

	// Events
	public event QuotationNotifier notifyClients;

	private void UpdateCotation (float quot)
	{
		this.quot = quot;
		if (notifyClients != null) {
			notifyClients (quot);
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
