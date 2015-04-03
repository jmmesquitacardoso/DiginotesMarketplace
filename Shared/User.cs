using System;
using System.Collections;
using System.Collections.Generic;

namespace Shared
{
	public class User
	{
		HashSet<Diginote> wallet;

		public User ()
		{
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

