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

	// Orders creation

	public void AddPurchaseOrder(PurchaseOrder order) 
	{
		purchases.Enqueue(order);
	}

	public void AddSaleOrder(SaleOrder order)
	{
		sales.Enqueue(order);
	}

	// For editing orders

	public ArrayList GetUserPurchaseOrders(string username) {
		ArrayList userPurchases = new ArrayList ();

		for (int i = 0, l = purchases.Count; i < l; i++) {
			PurchaseOrder order = (PurchaseOrder)purchases[i];
			if (order.User == username) {
				userPurchases.Add (order);
			}
		}
		return userPurchases;
	}

	public ArrayList GetUserSaleOrders(string username) {
		ArrayList userSales = new ArrayList ();

		for (int i = 0, l = purchases.Count; i < l; i++) {
			SaleOrder order = (PurchaseOrder)purchases[i];
			if (order.User == username) {
				userSales.Add (order);
			}
		}
		return userSales;
	}

	public bool UpdatePurchaseOrder(int id, int amount) {
		PurchaseOrder purchase = null;
		for (int i = 0, l = sales.Count; i < l; i++) {
			if (((PurchaseOrder)purchases [i]).Id == id) {
				purchase = purchases [i];
				break;
			}
		}
		if (purchase == null) {
			return false;
		}

		purchase.Amount = amount;

		return true;
	}

	public bool UpdateSaleOrder(int id, int amount) {
		SaleOrder sale = null;
		for (int i = 0, l = sales.Count; i < l; i++) {
			if (((SaleOrder)sales [i]).Id == id) {
				sale = sales [i];
				break;
			}
		}

		if (sale == null) {
			return false;
		}

		ArrayList retrievedOrders = sale.RemoveDiginotes (amount);
		ArrayList userWallet = (ArrayList)wallets [sale.User];

		userWallet.AddRange (userWallet.Count - 1, retrievedOrders);

		return true;

	}

	// Order's dispatch

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

	public int GetDiginotesOnSaleCount() {
		int count = 0;

		for (int i = 0, l = sales.Count; i < l; i++) {
			count += ((SaleOrder)sales[i]).Diginotes.Count;
		}
		return count;
	}

	public ArrayList DispatchSaleOrders(int diginotesCount) {
		// TODO
	}
}
