using System;
using System.Runtime.Remoting;
using Common;

namespace Client
{
	public class ClientApp
	{
		// Attributes
		private ClientInterface parent;
        private IMarketplace SharedMarketplace { get; set; }
		private Intermediate Inter { get; set; }

		public ClientApp (ClientInterface parent)
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
			SharedMarketplace = (IMarketplace) RemoteNew.New(typeof(IMarketplace));
			this.parent = parent;
		}

		public void Register(string name, string username, string password, int diginotes)
        {
            Console.WriteLine("About to call Register");
            SharedMarketplace.Register(name, username, password, diginotes);
            Console.WriteLine("Ended Register call");
        }

		public Status Login(string username, string password)
        {
            Status result = SharedMarketplace.Login(username, password);
            Console.WriteLine("Will subscribe event");

			if (result == Status.Valid) {
				Inter = new Intermediate (SharedMarketplace);
				Inter.notifyClients += UpdateCotation;
			}

			return result;
        }

		public Status Logout (string username)
		{
            Status result = SharedMarketplace.Logout(username);

			if (result == Status.Valid) {
				Inter.notifyClients -= UpdateCotation;
			}

			return result;
        }

		public void UpdateCotation(float quot)
		{
			parent.UpdateQuotation (quot);
		}
	}
}
