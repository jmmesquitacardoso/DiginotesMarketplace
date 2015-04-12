using System;

namespace Common
{
	public delegate void OrdersNotifier (string username, OrderType type, int amount, float quot);

	public class OrdersIntermediate : MarshalByRefObject {

		public event OrdersNotifier notifyClients;

		public OrdersIntermediate(IMarketplace sharedMarketplace) {
			sharedMarketplace.notifyOrdClients += FireQuotNotify;
		}

		public void FireQuotNotify(string username, OrderType type, int amount, float quot) {
			notifyClients(username, type, amount, quot);
		}

		public override object InitializeLifetimeService() {
			return null;
		}
	}
}

