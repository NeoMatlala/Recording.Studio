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
        [HttpGet("get-all-bookings")]
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
        [HttpGet("get-booking/{id}")]
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

        // UPDATE booking
        [HttpPost("update-booking/{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] BookingWithSlotsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBooking = _db.Bookings.Include(b => b.User).Include(bs => bs.BookingSlots).ThenInclude(s => s.Slot).FirstOrDefault(b => b.BookingId == id);


            if (existingBooking == null)
            {
                return BadRequest("Booking not found");
            }

            existingBooking.UserId = model.UserId;
            existingBooking.Artist = model.Artist;
            existingBooking.Date = model.Date;
            existingBooking.PhoneNumber = model.PhoneNumber;
            existingBooking.Price = model.Price;

            _db.Bookings.Update(existingBooking);
            _db.SaveChanges();

            existingBooking.BookingSlots.Clear();

            foreach(var slotId in model.SlotIds)
            {
                var bookingSlot = new BookingSlot
                {
                    BookingId = existingBooking.BookingId,
                    SlotId = slotId
                };

                _db.BookingSlots.Add(bookingSlot);
            }

            _db.SaveChanges();

            return Ok(existingBooking);

        }

        // get bookings associated with a user
        [HttpGet("get-bookings-for-Id/{id}")]
        public IActionResult GetBookingsForId(string id)
        {
            var bookingsList = _db.Bookings.Include(bs => bs.BookingSlots).ThenInclude(s => s.Slot).Where(b => b.UserId == id).ToList();

            var bookings = bookingsList.Select(b => new BookingDTO
            {
                BookingId = b.BookingId,
                Artist = b.Artist,
                Date = b.Date,
                PhoneNumber = b.PhoneNumber,
                Price = b.Price,
                BookingSlots = b.BookingSlots.Select(bs => new BookingSlotDTO 
                { 
                    SlotId = bs.SlotId,
                }).ToList()

            }).ToList();

            return Ok(bookings);
        }

        // DELETE
        [HttpDelete("delete-booking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid Id");
            }

            var booking = _db.Bookings.Find(id);

            if(booking == null)
            {
                return NotFound("Booking not found");
            }

            _db.Remove(booking);
            _db.SaveChanges();

            return Ok(booking);
        }


        // CREATE
        [HttpPost("create-booking")]
        public IActionResult CreateBooking([FromBody] BookingWithSlotsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    // save booking info to booking table & save so that you take that ID and use it in bookingslot below
                    var booking = new Booking
                    {
                        UserId = model.UserId,
                        Artist = model.Artist,
                        Date = model.Date,
                        PhoneNumber = model.PhoneNumber,
                        Price = model.Price
                    };

                    _db.Bookings.Add(booking);
                    _db.SaveChanges();

                    // save to bookingslot table each slot associated with this booking ID 
                    foreach (var slotId in model.SlotIds)
                    {
                        var bookingSlot = new BookingSlot
                        {
                            BookingId = booking.BookingId,
                            SlotId = slotId
                        };

                        _db.BookingSlots.Add(bookingSlot);
                    }

                    _db.SaveChanges();

                    // Commit the transaction if everything was successful
                    transaction.Commit();

                    return Ok(booking);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    transaction.Rollback();
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }

            
        }
    }
}
