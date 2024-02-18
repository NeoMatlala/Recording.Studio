using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RR.API.Data;
using RR.API.Models;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamController(ApplicationDbContext db)
        {
            _db = db;
        }

        // CREATE 
        [HttpPost("create-team-member")]
        public IActionResult CreateTeamMember([FromForm] Team teamModel, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using(MemoryStream stream = new MemoryStream())
            {
                image.CopyTo(stream);
                
                var member = new Team
                {
                    Name = teamModel.Name,
                    Surname = teamModel.Surname,
                    Title = teamModel.Title,
                    Bio = teamModel.Bio,
                    Image = stream.ToArray()
                };

                _db.Team.Add(member);
                _db.SaveChanges();

                return Ok(member);
            }
        }

        // READ
        [HttpGet("get-team-members")]
        public IActionResult GetTeamMembers()
        {
            var members = _db.Team.ToList();

            return Ok(members);
        }

        // READ SINGLE
        [HttpGet("get-team-member/{id}")]
        public IActionResult GetTeamMember(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var member = _db.Team.Find(id);

            if(member == null)
            {
                return NotFound("User does not exist");
            }

            return Ok(member);
        }

        // UPDATE
        [HttpPut("update-team-member/{id}")]
        public IActionResult UpdateTeamMember(int id, [FromForm] Team teamModel, IFormFile? image)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var member = _db.Team.Find(id);

            if(member == null)
            {
                return NotFound("Member not found");
            }

            //member.Name = teamModel.Name;
            //member.Surname = teamModel.Surname;
            //member.Title = teamModel.Title;
            //member.Bio = teamModel.Bio;

            if (!string.IsNullOrEmpty(teamModel.Name))
            {
                member.Name = teamModel.Name;
            }

            if (!string.IsNullOrEmpty(teamModel.Surname))
            {
                member.Surname = teamModel.Surname;
            }

            if (!string.IsNullOrEmpty(teamModel.Title))
            {
                member.Title = teamModel.Title;
            }

            if (!string.IsNullOrEmpty(teamModel.Bio))
            {
                member.Bio = teamModel.Bio;
            }

            if (image != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.CopyTo(stream);

                    member.Image = stream.ToArray();
                }
            }

            _db.Team.Update(member);
            _db.SaveChanges();

            return Ok(member);
        }

        // DELETE
        [HttpDelete("delete-team-member/{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var member = _db.Team.Find(id);

            if (member == null)
            {
                return NotFound("User does not exist");
            } else
            {
                _db.Team.Remove(member);
                _db.SaveChanges();
            }

            return Ok(new {Message = true});
        }
    }
}
