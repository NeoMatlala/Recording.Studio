namespace RR.API.Models
{
    public class BookingSlot
    {
        public int BookingSlotId { get; set; }
        public int BookingId { get; set; }
        public int SlotId { get; set; }

        public Booking Booking { get; set; }
        public Slot Slot { get; set; }
    }
}
