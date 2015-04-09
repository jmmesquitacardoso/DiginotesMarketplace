using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{

    [Serializable]
    public class SaleOrder
    {
        User User { get; set; }
        int Amount { get; set; }
        ArrayList Diginotes { get; set; }

        public SaleOrder(User user, int amount)
        {
            User = user;
            Amount = amount;
        }

        public void AddDiginotes(ArrayList diginotes)
        {
            Diginotes = diginotes;

        }
    }
}
