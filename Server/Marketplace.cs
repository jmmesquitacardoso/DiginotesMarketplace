using System;
using System.Collections;
using Shared;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{
		public enum Status { Valid, Invalid, SharedObjError };

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
        public int Register(string username, string password)
        {
            Console.WriteLine("Register Server side");
			if (Database.Instance.getUsers().
            User user = new User(username, password);
            return Database.Instance.AddUser(username, user);
        }

        public int Login(string username, string password)
        {
            Console.WriteLine("Login Server side");
            if (Database.Instance.getUsers().Contains(username) && String.Equals(Database.Instance.getUserByUsername(username).Password, password))
            {
                User user = new User(username, password);
                usersLoggedIn.Add(username, user);
				return Status.Valid;
            }

            return Status.Invalid;
        }

        public int Logout(string username)
        {
            Console.WriteLine("Logout Server side");
            if (usersLoggedIn.Contains(username))
            {
                usersLoggedIn.Remove(username);
                return Status.Valid;
            }
            return Status.Invalid;
        }
	}
}
