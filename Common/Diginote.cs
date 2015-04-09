using System;

namespace Common
{
	[Serializable]
	public class Diginote
	{
		private static int counter = 0;

        public int Id { get; set; }
        public int Value { get; set; }
		public User Owner { get; set; }

		public Diginote (User owner)
		{
			Id = ++counter;
			Value = 1;
			Owner = owner;
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

