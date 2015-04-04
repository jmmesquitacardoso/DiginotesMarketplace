﻿using System;
using System.Collections;

namespace Shared
{
	public class User
	{
		private Hashtable wallet;

        public string Username { get; set; }
        public string Password { get; set; }

		public User (string username, string password)
		{
            Username = username;
            Password = password;
            wallet = new Hashtable();
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
				wallet.Add (diginote.Id, diginote);
			}
        }
	}
}

