namespace RR.API.Models
{
    public class PaymentWithSlot
    {
        public int PaymentId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public List<int> SlotIds { get; set; }
    }
}
