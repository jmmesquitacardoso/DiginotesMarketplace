using System;

namespace Common
{
	public delegate void QuotationNotifier (float quot);

	public class Intermediate : MarshalByRefObject {

		public event QuotationNotifier notifyClients;


		public Intermediate(IMarketplace sharedMarketplace) {
			sharedMarketplace.notifyClients += FireQuotNotify;
		}

		public void FireQuotNotify(float quot) {
			notifyClients(quot);
		}

		public override object InitializeLifetimeService() {
			return null;
		}
	}
}

