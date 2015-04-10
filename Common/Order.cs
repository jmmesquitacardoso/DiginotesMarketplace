using System;

namespace Common
{
	public class Order
	{
		public User User { get; }
		public int Amount { get; }

		public Order (User user, int amount)
		{
			User = user;
			Amount = amount;
		}
	}
}

