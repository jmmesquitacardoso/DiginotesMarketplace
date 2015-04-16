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
	private Hashtable balances;
	private Hashtable ordersHistory;
	private Queue purchases;
	private Queue sales;

	public float Quotation { get; set; }

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
		balances = new Hashtable ();
        ordersHistory = new Hashtable();
        Quotation = 1;
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
		balances.Add (user.Username, ((float)0.0));
		ordersHistory.Add (user.Username, new ArrayList ());
		SaveDatabase ();

		return Status.Valid;
	}

	public User GetUserByUsername (string username)
	{
		return (User)registeredUsers [username];
	}

	public float GetUserBalance (string username)
	{
		return (float)balances [username];
	}

	public void SetUserBalance (string username, float balance)
	{
		balances [username] = balance;
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
		} else {
			wallets.Add (username, diginotes);
		}
		SaveDatabase ();
		return Status.Valid;
	}

	public ArrayList RemoveDiginotesFromUser (string username, int count)
	{
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
			returnDiginotes = new ArrayList (userDiginotes.GetRange (0, count));
		}

		SaveDatabase ();
		return returnDiginotes;
	}

	public ArrayList GetUserDiginotes (string username)
	{
		if (!wallets.Contains (username)) {
			return null;
		}

		return (ArrayList)wallets [username];
	}

	// Orders creation

	public void AddPurchaseOrder (PurchaseOrder order)
	{
		purchases.Enqueue (order);
		SaveDatabase ();
	}

	public void AddSaleOrder (SaleOrder order)
	{
		sales.Enqueue (order);
		SaveDatabase ();
	}

	// For editing orders

	public ArrayList GetUserPurchaseOrders (string username)
	{
		ArrayList userPurchases = new ArrayList ();

		foreach (PurchaseOrder order in purchases) {
			if (order.User.Equals (username)) {
				userPurchases.Add (order);
			}
		}

		return userPurchases;
	}

	public ArrayList GetUserSaleOrders (string username)
	{
		ArrayList userSales = new ArrayList ();


		foreach (SaleOrder order in sales) {
			if (order.User.Equals (username)) {
				userSales.Add (order);
			}
		}

		return userSales;
	}

	public bool UpdatePurchaseOrder (int id, int amount)
	{
		PurchaseOrder purchase = null;

		foreach (PurchaseOrder order in purchases) {
			if (order.Id == id) {
				purchase = order;

				if (amount == 0) {
					order.Amount = 0;
				}

				break;
			}
		}


		if (purchase == null) {
			return false;
		}

		purchase.Amount = amount;

		SaveDatabase ();

		return true;
	}

	public bool UpdateSaleOrder (int id, int amount)
	{
		SaleOrder sale = null;

		foreach (SaleOrder order in sales) {
			if (order.Id == id) {
				sale = order;

				if (amount == 0) {
					order.Amount = 0;
				}
			}
		}

		if (sale == null) {
			return false;
		}

		ArrayList retrievedOrders = sale.RemoveDiginotes (amount);
		ArrayList userWallet = (ArrayList)wallets [sale.User];

		userWallet.InsertRange (userWallet.Count - 1, retrievedOrders);

		SaveDatabase ();

		return true;

	}

	// Order's dispatch

	public PurchaseOrder GetOldestPurchaseOrder ()
	{
		if (purchases.Count == 0) {
			return null;
		}

		while (purchases.Count > 0 && ((PurchaseOrder)purchases.Peek ()).Amount == 0) {
			purchases.Dequeue ();
		}

		return (PurchaseOrder)purchases.Peek ();
	}

	public SaleOrder GetOldestSaleOrder ()
	{
		if (sales.Count == 0) {
			return null;
		}

		while (sales.Count > 0 && ((SaleOrder)sales.Peek ()).Amount == 0) {
			sales.Dequeue ();
		}

		return (SaleOrder)sales.Peek ();
	}

	public void UpdateOldestPurchaseOrder (int amount)
	{
		if (amount == 0) {
			purchases.Dequeue ();
		} else {
			((PurchaseOrder)purchases.Peek ()).Amount = amount;
		}
		SaveDatabase ();
	}

	public int GetDiginotesOnSaleCount ()
	{
		int count = 0;

		foreach (SaleOrder order in sales) {
			count += order.Diginotes.Count;
		}

		return count;
	}

	public bool IsOrderPending (int orderId)
	{

		foreach (SaleOrder order in sales) {
			if (order.Id == orderId) {
				return true;
			}
		}

		foreach (PurchaseOrder order in purchases) {
			if (order.Id == orderId) {
				return true;
			}
		}

		return false;
	}

	public ArrayList RemoveFromOldestSale (int amount)
	{

		while (sales.Count > 0 && ((SaleOrder)sales.Peek ()).Amount == 0) {
			sales.Dequeue ();
		}

		ArrayList result = new ArrayList ();

		SaleOrder order = (SaleOrder)sales.Peek ();

		if (order.Amount >= amount) {
			result.AddRange (order.RemoveDiginotes (amount));

			if (order.Amount == amount) {
				sales.Dequeue ();
			} else {
				result.AddRange (order.RemoveDiginotes (order.Amount));
				sales.Dequeue ();
			}
		}

		return result;
	}

	public ArrayList GetPastOrders (string username)
	{
		return (ArrayList) ordersHistory [username];
	}

	public void AddOrderRecord (string username, OrderType type, int amount, float quot)
	{
		((ArrayList)ordersHistory [username]).Add (new OrderRecord(type, amount, quot));
	}
}
