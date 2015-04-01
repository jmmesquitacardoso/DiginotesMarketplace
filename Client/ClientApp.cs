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
            RemotingConfiguration.Configure("ClientApp.exe.config", false);
            sharedMarketplace = new Marketplace();
		}

        public void Register(string username, string password)
        {
            sharedMarketplace.Register(username, password);
        }

        public int Login(string username, string password)
        {
            return sharedMarketplace.Login(username, password);
        }

        public int Logout(string username)
        {
            return sharedMarketplace.Logout(username);
        }
	}
}

