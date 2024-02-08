using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.API.Data;
using RR.API.DTOs;
using RR.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PaymentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ
        [HttpGet("GetPayments")]
        public IActionResult GetPayments()
        {
            var payments = _db.Payments.Include(b => b.User).Include(ps => ps.PaymentSlots).ThenInclude(s => s.Slot);

            var paymentDTO = payments.Select(p => new PaymentDTO
            {
                PaymentId = p.PaymentId,
                UserName = p.User.UserName,
                Amount = p.Amount,
                Date = p.Date,
                PaymentSlots = p.PaymentSlots.Select(ps => new PaymentSlotDTO
                {
                    SlotId = ps.Slot.SlotId
                }).ToList()
            }).ToList();

            return Ok(paymentDTO);

        }

        //READ SINGLE PAYMENT
        [HttpGet("get-payment/{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _db.Payments.Include(p => p.User).Include(ps => ps.PaymentSlots).FirstOrDefault(p => p.PaymentId == id);

            if (payment == null)
            {
                return NotFound("Payment does not exist");
            }

            var paymentDTO = new PaymentDTO
            {
                PaymentId = payment.PaymentId,
                UserName = payment.User.UserName,
                Amount = payment.Amount,
                Date = payment.Date,
                PaymentSlots = payment.PaymentSlots.Select(ps => new PaymentSlotDTO
                {
                    SlotId = ps.SlotId
                }).ToList()
            };

            return Ok(paymentDTO);
        }

        // CREATE
        [HttpPost("create-payment")]
        public IActionResult CreatePayment([FromBody] PaymentWithSlot model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // save payment info first
            var payment = new Payment
            {
                PaymentId = model.PaymentId,
                UserId = model.UserId,
                Amount = model.Amount,
                Date = model.Date
            };

            _db.Payments.Add(payment);
            _db.SaveChanges();

            // save paymentSlot info
            foreach(var slotId in model.SlotIds)
            {
                var paymentSlot = new PaymentSlot
                {
                    PaymentId = payment.PaymentId,
                    SlotId = slotId
                };

                _db.PaymentSlots.Add(paymentSlot);
            }

            _db.SaveChanges();

            return Ok(payment);
        }
    }
}
