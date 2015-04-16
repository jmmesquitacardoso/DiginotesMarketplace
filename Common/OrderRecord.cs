using System;
using Common;

namespace Common
{
	public class OrderRecord
	{
		public OrderType Type { get; }
		public int Amount { get; }
		public float Quotation { get; }

		public OrderRecord(OrderType type, int amount, float quot) {
			Type = type;
			Amount = amount;
			Quotation = quot;
		}
	}
}

