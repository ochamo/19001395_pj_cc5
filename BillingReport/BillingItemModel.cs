using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingReport
{
    public class BillingItemModel
    {
        public string BillingItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public BillingItemModel(string billingItemName, int quantity, decimal price)
        {
            BillingItemName = billingItemName;
            Quantity = quantity;
            Price = price;
        }
    }
}
