namespace RR.API.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }

        // Other properties as needed
        public List<BookingSlotDTO> BookingSlots { get; set; }
    }
}
