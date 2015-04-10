using System;

namespace Common
{
	public class PurchaseOrder : Order
    {
		public PurchaseOrder(User user, int amount) : base(user, amount)
        {
        }
    }
}
