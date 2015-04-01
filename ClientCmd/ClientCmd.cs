using System;
using System.Runtime.Remoting;
using Client;

namespace ClientCmd
{
	public class ClientCmd
	{
        public static void Main(string[] args)
        {
            string username, password;
            ClientApp cap = new ClientApp();

            Console.WriteLine("Introduza o seu username: ");
            username = Console.ReadLine();
            Console.WriteLine("Introduza a sua password: ");
            password = Console.ReadLine();

            cap.Register(username, password);
            
            Console.ReadLine();
        }
	}
}

