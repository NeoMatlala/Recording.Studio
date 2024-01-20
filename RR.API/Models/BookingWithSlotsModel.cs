using Microsoft.AspNetCore.Identity;

namespace RR.API.Models
{
    public class BookingWithSlotsModel
    { 
        public string UserId { get; set; } 
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }

        public List<int> SlotIds { get; set; }
    }
}
