using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
	[Serializable]
    class Order
    {
        public enum Type { Buy, Sell };
        Type OrderType { get; set; }
        User User { get; set; }
        int Amount { get; set; }

        public Order(Type type, User user, int amount)
        {
            OrderType = type;
            User = user;
            Amount = amount;
        }
    }
}
