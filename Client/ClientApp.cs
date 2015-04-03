using System;
using System.Runtime.Remoting;
using Server;

namespace Client
{
	public class ClientApp
	{
		// Attributes
		private ClientInterface parent;

        Marketplace sharedMarketplace;
		public ClientApp (ClientInterface parent)
        {
            RemotingConfiguration.Configure("ClientApp.exe.config", false);
            sharedMarketplace = new Marketplace();
			this.parent = parent;
		}

		public void Register(string username, string password, int diginotes)
        {
			sharedMarketplace.Register(username, password, diginotes);
        }

		public Marketplace.Status Login(string username, string password)
        {
			Marketplace.Status result = sharedMarketplace.Login(username, password);

			if (result == Marketplace.Status.Valid) {
				parent.UpdateQuotation (sharedMarketplace.Quotation);
				sharedMarketplace.notifyClients += this.UpdateCotation;
			}

			return result;
        }

		public Marketplace.Status Logout (string username)
		{
			Marketplace.Status result = sharedMarketplace.Logout (username);

			if (result == Marketplace.Status.Valid) {
				sharedMarketplace.notifyClients -= this.UpdateCotation;
			}

			return result;
        }

		public void UpdateCotation(float quot)
		{
			parent.UpdateQuotation (quot);
		}
	}
}
