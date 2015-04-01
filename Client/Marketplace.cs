using System;

namespace Server
{
	public class Marketplace : MarshalByRefObject
	{

		public Marketplace ()
		{
		}

		public void Register(string username, string password)
		{
		}

		public int Login(string username, string password)
		{
			return -1;
		}

		public int Logout(string username)
		{
            return -1;
		}
	}
}
