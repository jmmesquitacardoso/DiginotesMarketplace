using System;
using Common;

namespace Client
{
	public interface ClientInterface
	{
		void UpdateQuotation(float quot);
		void AskNewQuotation(float currentQuot, OrderType type);
		void NotifyOrderUpdate(OrderType type, int amount, float quot);
	}
}

