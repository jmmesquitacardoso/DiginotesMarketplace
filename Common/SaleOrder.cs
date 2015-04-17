using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{

	[Serializable]
	public class SaleOrder: Order
	{
        public ArrayList Diginotes { get; set;  }

		public SaleOrder (string user, int amount) : base (user, amount)
		{
			Diginotes = new ArrayList ();
		}

		public void AddDiginotes (ArrayList diginotes)
		{
			Diginotes.AddRange(diginotes);
		}

		public ArrayList RemoveDiginotes (int count)
		{
			if (count > Diginotes.Count || count < 0) {
				return null;
			}

			Amount -= count;

			ArrayList result = Diginotes.GetRange (0, count);
			Diginotes.RemoveRange (0, count);
			return result;
		}
	}
}
