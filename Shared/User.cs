using System;
using System.Collections;
using System.Collections.Generic;

namespace Shared
{
	public class User
	{
		HashSet<Diginote> wallet;
        public string Username { get; set; }
        public string Password { get; set; }

		public User (string username, string password)
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
				// TODO
			}
		}

		public override int GetHashCode ()
		{
			// TODO
		}
	}
}

