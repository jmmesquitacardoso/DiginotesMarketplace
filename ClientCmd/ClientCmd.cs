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
            int op = -1;
            string dummy;
            ClientApp cap = new ClientApp();

            Console.WriteLine("Introduza o seu username: ");
            username = Console.ReadLine();
            Console.WriteLine("Introduza a sua password: ");
            password = Console.ReadLine();

            while (op != 3)
            {
                Console.WriteLine("Bem-vindo ao Diginotes Marketplace!\nEscolha a ação que deseja:");
                Console.WriteLine(" 1 - Registar-se");
                Console.WriteLine(" 2 - Login");
                Console.WriteLine(" 3 - Logout");
                dummy = Console.ReadLine();
                op = Int32.Parse(dummy);
                switch (op)
                {
                    case 1: cap.Register(username, password);
                            Console.WriteLine("Registado, prima Enter para continuar");
                            Console.ReadLine();
                            break;
                    case 2: if (cap.Login(username, password) == 1)
                            {
                                Console.WriteLine("Login feito com sucesso, prima Enter para continuar");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Erro ao fazer login");
                            }
                            break;
                    case 3: if (cap.Logout(username) == 1)
                            {
                                Console.WriteLine("Logout feito com sucesso");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Erro ao fazer logout");
                                Console.ReadLine();
                            }
                            break;
                    default: break;
                }
            }
        }
	}
}

