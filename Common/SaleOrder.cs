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
		}

		public ArrayList RemoveDiginotes (int count)
		{
			if (count < 0) {
				return null;
			}

			count = Math.Min (count, Amount);

			Amount -= count;

			Diginote[] result = new Diginote[count];

			Diginotes.CopyTo (0, result, 0, Diginotes.Count - count);

			Diginotes.RemoveRange (0, count);

			return new ArrayList(result);
		}
	}
}
