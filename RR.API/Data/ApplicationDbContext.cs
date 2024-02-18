using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RR.API.Models;

namespace RR.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSlot> BookingSlots { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentSlot> PaymentSlots { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
