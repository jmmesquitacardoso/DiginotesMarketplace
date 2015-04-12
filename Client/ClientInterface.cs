using System;
using Common;

namespace Client
{
	public interface ClientInterface
	{
		void UpdateQuotation(float quot);
		float AskNewQuotation();
		void NotifyOrderUpdate(OrderType type, int amount, float quot);
	}
}

