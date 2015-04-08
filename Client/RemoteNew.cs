using System;
using System.Collections;
using System.Runtime.Remoting;

namespace Client
{
	class RemoteNew {
		private static Hashtable types = null;

		private static void InitTypeTable() {
			types = new Hashtable();
			foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
				types.Add(entry.ObjectType, entry);
		}

		public static object New(Type type) {
			if (types == null)
				InitTypeTable();
			Console.WriteLine (types);
			WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
			if (entry == null)
				throw new RemotingException("Type not found!");
			return RemotingServices.Connect(type, entry.ObjectUrl);
		}
	}
}

