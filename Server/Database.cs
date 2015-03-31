using System;
using System.Collections;

namespace Server
{
	[Serializable]
	public class Database
	{
		private Hashtable RegisteredUsers = new Hashtable();

		public Database ()
		{
		}
	}
}

