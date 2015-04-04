﻿using System;
using System.Runtime.Remoting;
using Server;

namespace Client
{
	public class ClientApp
	{
		// Attributes
		private ClientInterface parent;

        public Marketplace SharedMarketplace { get; set; }
		public ClientApp (ClientInterface parent)
        {
            RemotingConfiguration.Configure("ClientApp.exe.config", false);
            SharedMarketplace = new Marketplace();
			this.parent = parent;
		}

		public void Register(string username, string password, int diginotes)
        {
            Console.WriteLine("About to call Register");
            SharedMarketplace.Register(username, password, diginotes);
            Console.WriteLine("Ended Register call");
        }

		public Marketplace.Status Login(string username, string password)
        {
            Marketplace.Status result = SharedMarketplace.Login(username, password);

			if (result == Marketplace.Status.Valid) {
                parent.UpdateQuotation(SharedMarketplace.Quotation);
                SharedMarketplace.notifyClients += this.UpdateCotation;
			}

			return result;
        }

		public Marketplace.Status Logout (string username)
		{
            Marketplace.Status result = SharedMarketplace.Logout(username);

			if (result == Marketplace.Status.Valid) {
                SharedMarketplace.notifyClients -= this.UpdateCotation;
			}

			return result;
        }

		public void UpdateCotation(float quot)
		{
			parent.UpdateQuotation (quot);
		}
	}
}
