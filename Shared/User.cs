using System;
using System.Collections;

namespace Shared
{
	public class User
	{
		private Hashtable wallet;

        public string Username { get; }
		public string Password { get; }

		public User (string username, string password, int diginotes)
		{
            Username = username;
            Password = password;

			for (int i = 0; i < diginotes; i++) {
				Diginote diginote = new Diginote ();
				wallet.Add (diginote.Id, diginote);
			}
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
	}
}

