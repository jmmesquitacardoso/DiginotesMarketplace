using System;
using System.Collections;
using Common;

public interface IMarketplace
{
	event QuotationNotifier notifyClients;

	float Quotation { get; }

    Status addSaleOrders(string username, int nOrders);

    void addPurchaseOrders(string username, int nOrders);

	Status Register (string name, string username, string password, int diginotes);

	Status Login (string username, string password);

	Status Logout (string username);
}