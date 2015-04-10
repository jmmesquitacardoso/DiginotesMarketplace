using System;

namespace Common
{
	[Serializable]
	public abstract class Order
	{
		private static int counter = 0;

		public string User { get; }

		public int Amount { get; set; }

		public int Id { get; }

		public Order (string user, int amount)
		{
			User = user;
			Amount = amount;
			Id = ++counter;
		}

		public override bool Equals (object obj)
		{
			if (obj == null) {
				return base.Equals (obj);
			}

			if (!(obj is Order)) {
				throw new InvalidCastException ("The Object isn't of Type Order.");
			} else {
				return Id.Equals((obj as Order).Id);
			}
		}

		public override int GetHashCode ()
		{
			return Id.GetHashCode();
		}

		public Order Clone() {
		}
	}
}

