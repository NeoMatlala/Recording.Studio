using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace RR.API.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; } // Assuming UserId is the foreign key
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }

        // Navigation property for the User (assuming User is the related entity)
        public IdentityUser User { get; set; }

        // Collection navigation property for the BookingSlots
        [JsonIgnore]
        public List<BookingSlot> BookingSlots { get; set; }
    }
}
