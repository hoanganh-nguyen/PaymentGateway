namespace PaymentGateway.Models
{
    public class PaymentInfo
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public CreditCard Card { get; set; }
        public Amount Amount { get; set; }
        public DateTime LastUpdate { get; set; }

        public PaymentInfo()
        {
        }
    }
}
