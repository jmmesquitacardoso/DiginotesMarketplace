using System;

namespace Common
{
    public class PurchaseOrder
    {
        User User { get; set; }
        int Amount { get; set; }

        public PurchaseOrder(User user, int amount)
        {
            User = user;
            Amount = amount;
        }

    }
}
