using System;
using System.Runtime.Remoting;
using Shared;

namespace Client
{
	public class ClientApp
	{
		public ClientApp ()
		{
		}

		static void Main (string[] args)
		{
			RemotingConfiguration.Configure ("ClientApp.exe.config", false);
			Marketplace sharedMarketplace = new Marketplace ();
			Console.WriteLine ("Press Enter to exit");
			Console.ReadLine ();
		}
	}
}

