using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{

	public enum OrderType { Purchase, Sale };

	[Serializable]
    public class Order
    {
        OrderType Type { get; set; }
        User User { get; set; }
        int Amount { get; set; }

		public Order(OrderType type, User user, int amount)
        {
            Type = type;
            User = user;
            Amount = amount;
        }
    }
}
