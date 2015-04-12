using System;
using System.Collections;
using Common;

public interface IMarketplace
{
	event QuotationNotifier notifyQuotClients;

	event OrdersNotifier notifyOrdClients;

	float Quotation { get; }

	void UpdateQuotation (float quot);

	Status Register (string name, string username, string password, int diginotes);

	Status Login (string username, string password);

	Status Logout (string username);

	int GetUserDiginotes(string username);

	Status addSaleOrders (string username, int nOrders);

	ArrayList GetUserSaleOrders (string username);

	bool UpdateSaleOrder (int id, int amount);

	Status addPurchaseOrders (string username, int nOrders);

	ArrayList GetUserPurchaseOrders (string username);

	bool UpdatePurchaseOrder(int id, int amount);
}