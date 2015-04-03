using System;
using System.Collections;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{
		// Members
        private ArrayList usersLoggedIn;
		private float cot;

		// Delegate types
		delegate float CotationNotifier();

		// Events
		public event CotationNotifier notifyClients;
		private void UpdateCotation (float cot)
		{
			this.cot = cot;
			notifyClients(cot);
		}

		// Properties
		public float Cotation {
			get{
				return cot;
			}
		}
        
		// Constructor
		public Marketplace ()
        {
            usersLoggedIn = new ArrayList();
		}

		// Methods
        public void Register(string username, string password)
        {
            Console.WriteLine("Register Server side");
            Database.Instance.AddUser(username, password);
        }

        public int Login(string username, string password)
        {
            Console.WriteLine("Login Server side");
            if (Database.Instance.getUsers().Contains(username) && String.Equals(Database.Instance.getUsers()[username], password))
            {
                usersLoggedIn.Add(username);
                return 1;
            }

            return 0;
        }

        public int Logout(string username)
        {
            Console.WriteLine("Logout Server side");
            if (usersLoggedIn.Contains(username))
            {
                usersLoggedIn.Remove(username);
                return 1;
            }
            return 0;
        }
	}
}
