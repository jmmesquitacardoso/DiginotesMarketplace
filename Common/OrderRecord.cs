using System;
using Common;

namespace Common
{
    [Serializable]
	public class OrderRecord
	{
		public OrderType Type { get; set; }
		public int Amount { get; set; }
		public float Quotation { get; set; }

		public OrderRecord(OrderType type, int amount, float quot) {
			Type = type;
			Amount = amount;
			Quotation = quot;
		}
	}
}

