using System;
using System.Collections;

namespace Common
{
	[Serializable]
	public class User
	{
        public Hashtable Wallet {get; set;}
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

		public User (string name, string username, string password)
		{
            Name = name;
            Username = username;
            Password = password;
            Wallet = new Hashtable();
		}

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

		public override bool Equals (object obj)
		{
			if (obj == null) {
				return base.Equals (obj);
			}

			if (!(obj is User)) {
				throw new InvalidCastException ("The Object isn't of Type User.");
			} else {
				return Username.Equals((obj as User).Username);
			}
		}

		public override int GetHashCode ()
		{
			return Username.GetHashCode();
		}

        public void AddDiginotes(int diginotes) {
            for (int i = 0; i < diginotes; i++)
            {
				Diginote diginote = new Diginote (this);
				Wallet.Add (diginote.Id, diginote);
			}
        }
	}
}

