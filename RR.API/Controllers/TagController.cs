using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RR.API.Data;
using RR.API.DTOs;
using RR.API.Models;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ
        [HttpGet("get-tags")]
        public IActionResult GetTags()
        {
            var tags = _db.Tags.Select(t => new { t.TagId, t.TagName }).ToList();

            return Ok(tags);
        }

        [HttpGet("get-tag/{id}")]
        public IActionResult GetTag(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return NotFound("Tag not found");
            }

            return Ok(new { tag.TagId, tag.TagName });

        }

        // CREATE
        [HttpPost("create-tag")]
        public IActionResult CreateTag([FromBody] CreateTagDTO createTagDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = new Tag
            {
                TagName = createTagDTO.TagName,
            };

            _db.Tags.Add(tag);
            _db.SaveChanges();

            return Ok(tag);
        }

        // UPDATE
        [HttpPut("update-tag/{id}")]
        public IActionResult UpdateTag(int id, [FromBody] CreateTagDTO updateTagDTO)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return NotFound("Tag not found");
            }

            if (!string.IsNullOrEmpty(updateTagDTO.TagName))
            {
                tag.TagName = updateTagDTO.TagName;
            }

            _db.Tags.Update(tag);
            _db.SaveChanges();

            return Ok(tag);
        }

        // DELETE
        [HttpDelete("delete-tag/{id}")]
        public IActionResult DeleteTag(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var tag = _db.Tags.Find(id);

            if (tag == null)
            {
                return NotFound("Tag not found");
            }

            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return Ok(tag);
        }
    }
}
