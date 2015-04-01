using System;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{
        
		public Marketplace ()
		{
		}

        public void Register(string username, string password)
        {
            Console.WriteLine("Server side");
            Database.Instance.AddUser(username, password);
        }

        public int Login(string username, string password)
        {
            if (Database.Instance.getUsers().Contains(username) && String.Equals(Database.Instance.getUsers()[username], password))
            {
                return 1;
            }

            return 0;
        }

        public void Logout(string username)
        {

        }
	}
}

