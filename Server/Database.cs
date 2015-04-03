using System;
using System.Collections;
using Shared;

namespace Server
{
	[Serializable]
	public class Database
	{
        private static Database instance;

		private Hashtable registeredUsers = new Hashtable();

		public Database ()
		{
		}

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public void AddUser(string key, User value) {
            registeredUsers.Add(key, value);
        }

        public Hashtable getUsers()
        {
            return registeredUsers;
        }

        public User getUserByUsername(string username)
        {
            return (User) registeredUsers[username];
        }
	}
}

