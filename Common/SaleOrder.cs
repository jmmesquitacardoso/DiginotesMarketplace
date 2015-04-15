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
			Diginotes.InsertRange (Diginotes.Count - 1, diginotes);
		}

		public ArrayList RemoveDiginotes (int count)
		{
			if (count > Diginotes.Count || count < 0) {
				return null;
			}

			Amount -= count;

			return Diginotes.GetRange (0, count);
		}
	}
}
