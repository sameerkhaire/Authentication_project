

namespace CommonEntity
{
    public class ReceiptModel
    {
        public string PaymentId { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
