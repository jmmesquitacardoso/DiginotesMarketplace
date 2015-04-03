using System;
using System.Runtime.Remoting;
using Server;

namespace Client
{
	public class ClientApp
	{
		// Attributes
		private float quot;
		private ClientInterface parent;

        Marketplace sharedMarketplace;
		public ClientApp (ClientInterface parent)
        {
            RemotingConfiguration.Configure("ClientApp.exe.config", false);
            sharedMarketplace = new Marketplace();
			this.parent = parent;
		}

        public void Register(string username, string password)
        {
            sharedMarketplace.Register(username, password);
        }

        public int Login(string username, string password)
        {
            int result = sharedMarketplace.Login(username, password);

			if (result == 1) {
				quot = sharedMarketplace.Cotation;
				sharedMarketplace.notifyClients += this.UpdateCotation;
			}

			return result;
        }

        public int Logout (string username)
		{
			int result = sharedMarketplace.Logout (username);

			if (result == 1) {
				sharedMarketplace.notifyClients -= this.UpdateCotation;
			}
        }

		public int UpdateCotation(float quot)
		{
			this.quot = quot;
		}
	}
}
