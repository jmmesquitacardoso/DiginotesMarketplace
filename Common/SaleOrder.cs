﻿using System;
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
			Amount += diginotes.Count;
		}

		public ArrayList RemoveDiginotes (int count)
		{
			if (count < 0) {
				return null;
			}

			count = Math.Min (count, Amount);

			Amount -= count;

			ArrayList result = new ArrayList();

            result.AddRange(Diginotes.GetRange(0, count));

			Diginotes.RemoveRange (0, count);

			return new ArrayList(result);
		}
	}
}
