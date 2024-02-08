using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace RR.API.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public IdentityUser User { get; set; }

        // Collection navigation property for the BookingSlots
        [JsonIgnore]
        public List<PaymentSlot> PaymentSlots { get; set; }
    }
}
