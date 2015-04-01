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
            Console.WriteLine("Registado, prima Enter para continuar ");
            Console.ReadLine();
            if (cap.Login(username, password) == 1)
            {
                Console.WriteLine("Login feito com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao fazer login");
            }

            if (cap.Logout(username) == 1)
            {
                Console.WriteLine("Logout feito com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao fazer logout");
                Console.ReadLine();
            }

        }
	}
}

