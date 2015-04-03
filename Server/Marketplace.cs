using System;
using System.Collections;
using Shared;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{
		// Members
        private Hashtable usersLoggedIn;
		private float quot;

		// Delegate types
		delegate float QuotationNotifier();

		// Events
		public event QuotationNotifier notifyClients;
		private void UpdateCotation (float quot)
		{
			this.quot = quot;
			notifyClients(quot);
		}

		// Properties
		public float Quotation {
			get{
				return quot;
			}
		}
        
		// Constructor
		public Marketplace ()
        {
            usersLoggedIn = new Hashtable();
		}

		// Methods
        public void Register(string username, string password)
        {
            Console.WriteLine("Register Server side");
            User user = new User(username, password);
            Database.Instance.AddUser(username, user);
        }

        public int Login(string username, string password)
        {
            Console.WriteLine("Login Server side");
            if (Database.Instance.getUsers().Contains(username) && String.Equals(Database.Instance.getUserByUsername(username).Password, password))
            {
                User user = new User(username, password);
                usersLoggedIn.Add(username, user);
                return Status.Instance.UserAcess.Valid;
            }

            return Status.Instance.UserAcess.Invalid;
        }

        public int Logout(string username)
        {
            Console.WriteLine("Logout Server side");
            if (usersLoggedIn.Contains(username))
            {
                usersLoggedIn.Remove(username);
                return Status.Instance.UserAcess.Valid;
            }
            return Status.Instance.UserAcess.Invalid;
        }
	}
}
