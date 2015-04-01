using System;
using System.Runtime.Remoting;
using Server;

namespace Client
{
	public class ClientApp
	{
        Marketplace sharedMarketplace;
		public ClientApp ()
        {
		}

		static void Main (string[] args)
        {
            RemotingConfiguration.Configure("ClientApp.exe.config", false);
            Marketplace sharedMarketplace = new Marketplace();
            sharedMarketplace.Register("1", "2");
			Console.WriteLine ("Press Enter to exit");
			Console.ReadLine ();
		}

        public void Register(string username, string password)
        {
            sharedMarketplace.Register(username, password);
        }

        public int Login(string username, string password)
        {
            return sharedMarketplace.Login(username, password);
        }
	}
}

