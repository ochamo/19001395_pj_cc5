using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingReport
{
    public class BillingArgs
    {
        public int BillingId { get; set; }

        public string ClientBillingName { get; set; }
        public string ClientBillingId { get; set; }

        public string DeliveryAddress { get; set; }
        
        public List<BillingItemModel> BillingItemModels { get; set; }

        public decimal TotalPurchase { get; set; }

        public BillingArgs(int billingId, string clientBillingName, string clientBillingId, string deliveryAddress, List<BillingItemModel> billingItemModels, decimal totalPurchase)
        {
            BillingId = billingId;
            ClientBillingName = clientBillingName;
            ClientBillingId = clientBillingId;
            DeliveryAddress = deliveryAddress;
            BillingItemModels = billingItemModels;
            TotalPurchase = totalPurchase;
        }
    }
}
