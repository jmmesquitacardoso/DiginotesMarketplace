using System;

namespace Shared
{
	public class Diginote
	{
		private static int counter = 0;

		private int id;

		public int Id {
			get {
				return id;
			}
		}

		public Diginote ()
		{
			this.id = ++counter;
		}

		public override bool Equals (object obj)
		{
			if (obj == null) {
				return base.Equals (obj);
			}
			
			if (!(obj is User)) {
				throw new InvalidCastException ("The Object isn't of Type Diginote.");
			} else {
				return this.Id.Equals((obj as Diginote).Id);
			}
		}
		
		public override int GetHashCode ()
		{
			return Id.GetHashCode();
		}
	}
}

