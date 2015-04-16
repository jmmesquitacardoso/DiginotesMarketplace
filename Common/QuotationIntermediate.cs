using System;

namespace Common
{
	public delegate void QuotationNotifier (float quot);

	public class QuotationIntermediate : MarshalByRefObject {

		public event QuotationNotifier notifyClients;

		public QuotationIntermediate(IMarketplace sharedMarketplace) {
			sharedMarketplace.notifyQuotClients += FireQuotNotify;
		}

		public void FireQuotNotify(float quot) {
            Console.WriteLine("Quotation: {0}", quot);
			notifyClients(quot);
		}

		public override object InitializeLifetimeService() {
			return null;
		}
	}
}

