namespace RR.API.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }

        public List<PaymentSlotDTO> PaymentSlots { get; set; }
    }
}
