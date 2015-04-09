using System;
using System.Collections;
using Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

[Serializable]
public class Database
{
	private static Database instance;
	private Hashtable registeredUsers;
	private Hashtable wallets;
	private Queue purchases;
	private Queue sales;

	public Hashtable Users {
		get {
			return registeredUsers;
		}
	}

	private Database ()
	{
		registeredUsers = new Hashtable ();
		wallets = new Hashtable ();
		purchases = new Queue ();
		sales = new Queue ();
	}

	private void SaveDatabase ()
	{
		IFormatter formatter = new BinaryFormatter ();
		Stream stream = new FileStream ("diginotes_database.bin", 
			                FileMode.Create, 
			                FileAccess.Write, FileShare.None);
		formatter.Serialize (stream, this);
		stream.Close ();
	}

	public static Database Instance {
		get {
			if (instance == null) {

				// Load the database if it exists
				IFormatter formatter = new BinaryFormatter ();
				if (File.Exists ("diginotes_database.bin")) {
					Stream stream = new FileStream ("diginotes_database.bin",
						                FileMode.Open,
						                FileAccess.Read,
						                FileShare.Read);
					instance = (Database)formatter.Deserialize (stream);
					stream.Close ();
				} else {
					instance = new Database ();
				}

			}
			return instance;
		}
	}

	public Status AddUser (User user)
	{
		if (registeredUsers.Contains (user.Username)) {
			return Status.Invalid;
		}

		registeredUsers.Add (user.Username, user);
		SaveDatabase ();

		return Status.Valid;
	}

	public User GetUserByUsername (string username)
	{
		return (User)registeredUsers [username];
	}

	// Diginotes
	public Status AddDiginotesToUser (string username, ArrayList diginotes)
	{
		// Verify invariant
		// 	the diginotes of a user have a reference to it
		for (int i = 0, l = diginotes.Count; i < l; i++) {
			if (((Diginote)diginotes [i]).Owner != username) {
				return Status.Invalid;
			}
		}

		if (wallets.Contains (username)) {
			((ArrayList)wallets [username]).AddRange (diginotes);
        }
        else
        {
            wallets.Add(username, diginotes);
        }
		SaveDatabase ();
		return Status.Valid;
	}

	public ArrayList RemoveDiginotesFromUser(string username, int count) {
		// removes up to 'count' diginotes from the user 'username', removing and returning them

		if (!wallets.Contains (username)) {
			return null;
		}

		ArrayList userDiginotes = (ArrayList)wallets [username];

		ArrayList returnDiginotes;

		if (userDiginotes.Count <= count) {
			returnDiginotes = new ArrayList (userDiginotes);
			wallets [username] = new ArrayList ();
		} else {
			returnDiginotes = new ArrayList(userDiginotes.GetRange (0, count));
		}

		SaveDatabase ();
		return returnDiginotes;
	}

	public ArrayList GetUserDiginotes(string username) {
		if (!wallets.Contains(username)) {
			return null;
		}

		return (ArrayList)wallets [username];
	}

	// Orders
	public SaleOrder GetOldestPurchaseOrder() {
		if (purchases.Count == 0) {
			return null;
		}

		return (SaleOrder) purchases.Peek ();
	}

	public SaleOrder GetOldestSaleOrder() {
		if (sales.Count == 0) {
			return null;
		}

		return (SaleOrder) sales.Peek ();
	}

	public SaleOrder RemoveOldestPurchaseOrder() {
		if (purchases.Count == 0) {
			return null;
		}

		return (SaleOrder) purchases.Dequeue ();
	}

    public void AddPurchaseOrder(PurchaseOrder order) 
    {
        purchases.Enqueue(order);
    }

    public void AddSaleOrder(SaleOrder order)
    {
        sales.Enqueue(order);
    }
}
