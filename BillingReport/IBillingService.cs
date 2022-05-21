namespace BillingReport
{
    public interface IBillingService
    {
        public void SendBill(BillingArgs billingArgs);
    }
}