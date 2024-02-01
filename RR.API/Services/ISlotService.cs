using Microsoft.AspNetCore.Mvc;
using RR.API.Data;
using RR.API.Models;

namespace RR.API.Services
{
    public interface ISlotService
    {
        List<Slot> GetSlots();
        Slot GetSlot(int id);

    }

    public class SlotService : ISlotService
    {
        private readonly ApplicationDbContext _db;

        public SlotService(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ all slots
        public List<Slot> GetSlots()
        {
            var slots = _db.Slots.OrderBy(slot => slot.Name).ToList();

            return slots;
        }

        public Slot GetSlot(int id)
        {
            var slot = _db.Slots.Find(id);

            return slot;
        }

    }
}
