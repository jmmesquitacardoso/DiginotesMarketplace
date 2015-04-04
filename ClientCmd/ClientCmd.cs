using System;
using System.Runtime.Remoting;
using Client;

namespace ClientCmd
{
	public class ClientCmd : ClientInterface
	{
        public ClientCmd()
        {

        }

        private ClientApp getCap() 
        {
            return new ClientApp(this);
        }


        public static void Main(string[] args)
        {
            string username, password;
            ClientCmd cmd = new ClientCmd();


            Console.WriteLine("Introduza o seu username: ");
            username = Console.ReadLine();
            Console.WriteLine("Introduza a sua password: ");
            password = Console.ReadLine();

            cmd.InitialMenu(username,password);
        }

        private void InitialMenu(string username, string password)
        {
            int op = -1, diginotes;
            string dummy;
            ClientApp cap = getCap();

            while (op != 0)
            {
                Console.WriteLine("Bem-vindo ao Diginotes Marketplace!\nEscolha a ação que deseja:");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Registar-se");
                Console.WriteLine(" 2 - Login");
                dummy = Console.ReadLine();
                op = Int32.Parse(dummy);

                switch (op)
                {
                    case 0: break;
                    case 1: Console.WriteLine("Quantas Diginotes deseja? ");
                        dummy = Console.ReadLine();
                        diginotes = Int32.Parse(dummy);
                        cap.Register(username, password, diginotes);
                        Console.WriteLine("Registado, prima Enter para continuar");
                        Console.ReadLine();
                        break;
                    case 2: /*if (cap.Login(username, password) == cap.SharedMarketplace.Status.Valid)
                            {
                                Console.WriteLine("Login feito com sucesso, prima Enter para continuar");
                                Console.ReadLine();
                                InnerMenu(username);
                            }
                            else
                            {
                                Console.WriteLine("Erro ao fazer login");
                            }*/
                        cap.Login(username, password);
                        InnerMenu(username);
                        break;
                    default: break;
                }
            }
        }

        private void InnerMenu(string username)
        {
            int op = -1;
            string dummy;
            ClientApp cap = getCap();


            while (op != 0)
            {
                Console.WriteLine(" 0 - Logout");
                Console.WriteLine(" 1 - Emitir Ordem de Venda");
                Console.WriteLine(" 2 - Emitir Ordem de Compra");
                dummy = Console.ReadLine();
                op = Int32.Parse(dummy);

                switch (op)
                {
                    case 0: /*if (cap.Logout(username) == 1)
                            {
                                Console.WriteLine("Logout feito com sucesso");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Erro ao fazer logout");
                                Console.ReadLine();
                            }*/
                        cap.Logout(username);
                        break;
                    default: break;
                }
            }
        }

        public void UpdateQuotation(float quot)
        {
            Console.WriteLine("New Diginote Quotation: {0}", quot);
        }

	}
}

