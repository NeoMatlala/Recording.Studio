using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.API.Data;
using RR.API.DTOs;
using RR.API.Models;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BookingsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ
        [HttpGet("GetAllBookings")]
        public IActionResult GetBookings()
        {
            // query to include booking, users slot, bookingslot
            var bookings = _db.Bookings.Include(b => b.User).Include(bs => bs.BookingSlots).ThenInclude(s => s.Slot);

            // map to DTOs
            var bookingDTOs = bookings.Select(b => new BookingDTO
            {
                BookingId = b.BookingId,
                UserId = b.UserId,
                UserName = b.User.UserName,
                Artist = b.Artist,
                Date = b.Date,
                PhoneNumber = b.PhoneNumber,
                Price = b.Price,
                BookingSlots = b.BookingSlots.Select(bs => new BookingSlotDTO
                {
                    SlotId = bs.Slot.SlotId
                }).ToList()
            }).ToList();
            

            return Ok(bookingDTOs);
                
        }

        // READ single booking
        [HttpGet("GetBooking/{id}")]
        public IActionResult GetBooking(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid Id");
            }
            // query
            var booking = _db.Bookings.Include(b => b.User).Include(bs => bs.BookingSlots).ThenInclude(s => s.Slot).FirstOrDefault(b => b.BookingId == id);

            if(booking == null)
            {
                return BadRequest("Booking not found");
            }

            // DTO
            var bookingDTO = new BookingDTO
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                UserName = booking.User.UserName,
                Artist = booking.Artist,
                Date = booking.Date,
                PhoneNumber = booking.PhoneNumber,
                Price = booking.Price,
                BookingSlots = booking.BookingSlots.Select(bs => new BookingSlotDTO
                {
                    SlotId = bs.SlotId,
                }).ToList()
            };

            return Ok(bookingDTO);

        }
    }
}
