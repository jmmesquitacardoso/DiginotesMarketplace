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
        public ArrayList Diginotes { get; }

		public SaleOrder(User user, int amount) : base(user, amount)
		{
		}

        public void AddDiginotes(ArrayList diginotes)
        {
            Diginotes = diginotes;
        }
    }
}
