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

	ArrayList GetUserDiginotes(string username);

	OrderStatus AddSaleOrders (string username, int nOrders);

	ArrayList GetUserSaleOrders (string username);

	bool UpdateSaleOrder (int id, int amount);

	OrderStatus AddPurchaseOrders (string username, int nOrders);

	ArrayList GetUserPurchaseOrders (string username);

	bool UpdatePurchaseOrder(int id, int amount);
}