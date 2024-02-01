using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RR.API.Data;
using RR.API.Models;
using RR.API.Services;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ISlotService _slotService;

        public SlotController(ApplicationDbContext db, ISlotService slotService)
        {
            _db = db;
            _slotService = slotService;
        }

        // READ
        [HttpGet("GetSlots")]
        public IActionResult GetSlots()
        {
            var slots = _slotService.GetSlots();

            return Ok(slots);
        }

        // READ single slot
        [HttpGet("GetSlot/{id}")]
        public IActionResult GetSlot(int id) 
        {
            var slot = _slotService.GetSlot(id);

            if (slot == null)
            {
                return NotFound();
            }

            return Ok(slot);
        }

        // CREATE
        [HttpPost("CreateSlot")]
        public IActionResult CreateSlot([FromBody] Slot model)
        {
            if (ModelState.IsValid) 
            {
                var slot = new Slot
                {
                    Name = model.Name,
                    Time = model.Time,
                    Price = model.Price
                };

                _db.Slots.Add(slot);
                _db.SaveChanges();

                return Ok(_db.Slots.ToList());
            }
            
            return BadRequest("Some fields are invalid");

        }

        // Update
        [HttpPost("UpdateSlot/{id}")]
        public IActionResult UpdateSlot(int id, [FromBody] Slot model)
        {
            if (ModelState.IsValid)
            {
                var slot = _db.Slots.Find(id);

                if(slot == null)
                {
                    return NotFound("Slot not found");
                }

                slot.Name = model.Name;
                slot.Time = model.Time;
                slot.Price = model.Price;

                _db.SaveChanges();

                return Ok(slot);
            }

            return BadRequest("Some fields are invalid");
        }

        // DELETE
        [HttpDelete("DeleteSlot/{id}")]
        public IActionResult DeleteSlot(int id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid");
            }

            var slot = _db.Slots.Find(id);

            if (slot == null)
            {
                return NotFound("Slot not found");
            }

            _db.Slots.Remove(slot);
            _db.SaveChanges();

            return Ok(_db.Slots.ToList());
        }
    }
}
