using System;
using System.Collections;
using Common;

public interface IMarketplace
{
	event QuotationNotifier notifyClients;

	float Quotation { get; }

	Status Register (string name, string username, string password, int diginotes);

	Status Login (string name, string username, string password);

	Status Logout (string username);
}