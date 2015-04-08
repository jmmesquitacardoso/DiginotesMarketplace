using System;
using System.Collections;

public class Marketplace : MarshalByRefObject
{
	public enum Status
	{
		Valid,
		Invalid,
		SharedObjError}

	;

	public delegate void QuotationNotifier (float quot);

	public event QuotationNotifier notifyClients;

	public float Quotation;

	public Marketplace ()
	{
	}

	public Status Register (string name, string username, string password, int diginotes)
	{
		return Status.Valid;
	}

	public Status Login (string name, string username, string password)
	{
		return Status.Valid;
	}

	public Status Logout (string username)
	{
		return Status.Valid;
	}
}