using System;

namespace Common
{
	[Serializable]
	public class PurchaseOrder : Order
    {
		public PurchaseOrder(User user, int amount) : base(user, amount)
        {
        }
    }
}
