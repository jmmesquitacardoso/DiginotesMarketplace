﻿using System;
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
		ordersHistory = new Hashtable ();
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

		count = Math.Min (count, userDiginotes.Count);

		ArrayList returnDiginotes = new ArrayList ();

		returnDiginotes.AddRange (userDiginotes.GetRange (0, count));

		userDiginotes.RemoveRange (0, count);

		SaveDatabase ();
		return new ArrayList (returnDiginotes);
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
		foreach (PurchaseOrder order in purchases) {
			if (order.Id == id) {
				order.Amount = amount;
				break;
			}
		}

		SaveDatabase ();

		return true;
	}

	public bool UpdateSaleOrder (int id, int amount)
	{

		foreach (SaleOrder order in sales) {
			if (order.Id == id) {
				if (amount > order.Amount) {
					amount = amount - order.Amount;
					string username = order.User;

					ArrayList newDiginotes = RemoveDiginotesFromUser (username, amount);
					amount = newDiginotes.Count;
					Console.WriteLine (amount);

					order.AddDiginotes (newDiginotes);

					balances [username] = (float)balances [username] - amount * Quotation;
				} else {
					amount = order.Amount - amount;

					ArrayList retrievedOrders = order.RemoveDiginotes (amount);
					ArrayList userWallet = (ArrayList)wallets [order.User];
					userWallet.AddRange (retrievedOrders);

					balances [order.User] = (float)balances [order.User] + amount * Quotation;
				}

				break;
			}
		}

		SaveDatabase ();

		return true;

	}

	// Order's dispatch

	public PurchaseOrder GetOldestPurchaseOrder ()
	{
		while (purchases.Count > 0 && ((PurchaseOrder)purchases.Peek ()).Amount == 0) {
			purchases.Dequeue ();
		}

		if (purchases.Count == 0) {
			return null;
		}


		if (purchases.Count == 0) {
			return null;
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
		if (amount == ((PurchaseOrder)purchases.Peek ()).Amount) {
			purchases.Dequeue ();
		} else {
			((PurchaseOrder)purchases.Peek ()).Amount -= amount;
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
			if (order.Id == orderId && order.Amount > 0) {
				return true;
			}
		}

		foreach (PurchaseOrder order in purchases) {
			if (order.Id == orderId && order.Amount > 0) {
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

		if (sales.Count == 0) {
			return new ArrayList ();
		}

		SaleOrder order = (SaleOrder)sales.Peek ();

		Console.WriteLine ("Order amount: " + order.Amount);

		ArrayList result = order.RemoveDiginotes (amount);

		Console.WriteLine ("Order amount after add range: " + order.Amount);

		if (order.Amount >= amount) {
			while (sales.Count > 0 && ((SaleOrder)sales.Peek ()).Amount == 0) {
				sales.Dequeue ();
			}
		}

		SaveDatabase ();

		return result;
	}

	public ArrayList GetPastOrders (string username)
	{
		return (ArrayList)ordersHistory [username];
	}

	public void AddOrderRecord (string username, OrderType type, int amount, float quot)
	{
		((ArrayList)ordersHistory [username]).Add (new OrderRecord (type, amount, quot));
		SaveDatabase ();
	}
}
