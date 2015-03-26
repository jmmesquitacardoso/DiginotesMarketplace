using System;
using System.Runtime.Remoting;

namespace Server
{
	public class ServerApp
	{
		public ServerApp ()
		{
		}

		static void Main(string[] args) {
			RemotingConfiguration.Configure("ServerApp.exe.config", false);
			Console.WriteLine("[Server] hosting Diginotes Marketplace");
			Console.WriteLine("Press Enter to exit");
			Console.ReadLine();
		}
	}
}

