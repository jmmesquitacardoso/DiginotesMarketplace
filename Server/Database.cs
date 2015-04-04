using System;
using System.Collections;
using Shared;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Server
{
	[Serializable]
	public class Database
	{
        private static Database instance;

		private Hashtable registeredUsers = new Hashtable();

		public Hashtable Users {
			get {
				return registeredUsers;
			}
		}

		public Database ()
		{
			IFormatter formatter = new BinaryFormatter();
            if (File.Exists("diginotes_database.bin"))
            {
                Stream stream = new FileStream("diginotes_database.bin",
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                // Database obj = (Database) formatter.Deserialize(fromStream);
                stream.Close();
            }
		}

		private void SaveDatabase() {
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("diginotes_database.bin", 
				FileMode.Create, 
				FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
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

        public User getUserByUsername(string username)
        {
            return (User) registeredUsers[username];
        }
	}
}

