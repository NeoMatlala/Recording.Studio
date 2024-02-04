using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Drawing;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {

        private IConfiguration _configuration;

        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            //StripeConfiguration.ApiKey = "sk_test_51Oevw8Akocj1NhM27tLAmOl0f1SybvzfgLlctwhd9QL60lJ8XkvD4sUfmHiE6PF2WqMBWw9y7N1gp0N9uKnf0gEZ00mJoWy3K7";
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var options = new ProductListOptions { Limit = 3 };
            var service = new ProductService();
            StripeList<Product> products = service.List(options);

            return Ok(products);
        }

        [HttpPost("create-checkout-session/{bookingFee}")]
        public IActionResult CreateCheckoutSession(int bookingFee)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = "http://localhost:3000/booking-success",
                CancelUrl = "http://localhost:3000/booking-cancel",
                Mode = "payment",
                LineItems = new List<Stripe.Checkout.SessionLineItemOptions>
                {
                    new Stripe.Checkout.SessionLineItemOptions
                    {
                        //Price = priceId,
                        PriceData = new Stripe.Checkout.SessionLineItemPriceDataOptions
                        {
                            Currency = "zar",
                            ProductData = new Stripe.Checkout.SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Rehearsal Booking"
                            },
                            UnitAmount = bookingFee * 100
                        },
                        Quantity = 1
                    }
                }
            };

            var service = new Stripe.Checkout.SessionService();

            try 
            {
                var session = service.Create(options);
                return Ok(new { sessionId = session.Id });

            } catch(StripeException e)
            {
                return BadRequest(new { ErrorMessage = e.StripeError.Message });
            }
        }
    }
}
