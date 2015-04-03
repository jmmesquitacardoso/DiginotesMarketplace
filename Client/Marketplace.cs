using System;
using System.Collections;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{
		delegate float CotationNotifier();
		public event CotationNotifier notifyClients;

		public float Cotation {
			get;
		}

		public Marketplace ()
		{
		}

		public void Register(string username, string password)
		{
		}
		
		public int Login(string username, string password)
		{
			return 0;
		}
		
		public int Logout(string username)
		{
			return 0;
		}
	}
}
