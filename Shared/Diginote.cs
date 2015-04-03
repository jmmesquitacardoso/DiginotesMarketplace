using System;

namespace Shared
{
	public class Diginote
	{
		private static int counter = 0;

		private int id;

		public int Id {
			get {
				return id;
			}
		}

		public Diginote ()
		{
			this.id = ++counter;
		}
	}
}

