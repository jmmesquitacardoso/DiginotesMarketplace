using System;

namespace Common
{
	[Serializable]
	public class PurchaseOrder : Order
    {
		public PurchaseOrder(string user, int amount) : base(user, amount)
        {
        }
    }
}
