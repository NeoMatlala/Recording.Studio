namespace RR.API.Models
{
    public class PaymentSlot
    {
        public int PaymentSlotId { get; set; }
        public int PaymentId { get; set; }
        public int SlotId { get; set; }

        public Payment Payment  { get; set; }
        public Slot Slot { get; set; }
    }
}
