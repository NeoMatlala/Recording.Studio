using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RR.API.Data;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        public UsersController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // READ
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.Select(user => new
            {
                Id = user.Id,
                Email = user.Email
            }).ToList();

            return Ok(users);
        }
    }
}
