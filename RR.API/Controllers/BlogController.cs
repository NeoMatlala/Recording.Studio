using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.API.Data;
using RR.API.DTOs;
using RR.API.Models;
using System.IO;

namespace RR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ blogs
        [HttpGet("get-blog-posts")]
        public IActionResult GetBlogPosts()
        {
            var posts = _db.Blogs.Include(bt => bt.BlogTags);

            var postsWithTag = posts.Select(p => new
            {
                BlogId = p.BlogId,
                Title = p.Title,
                SubTitle = p.SubTitle,
                DatePublished = p.DatePublished,
                Body = p.Body,
                Image = p.Image,
                Tags = p.BlogTags.Select( bt => bt.Tag.TagName).ToList()
            }).ToList();

            return Ok(postsWithTag);
        }

        // READ Single blog post
        [HttpGet("get-blog-post/{id}")]
        public IActionResult GetBlogPost(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest("Invalid ID");
            }

            var post = _db.Blogs.Include(bt => bt.BlogTags).ThenInclude(bt => bt.Tag).FirstOrDefault(p => p.BlogId == id);

            if (post == null)
            {
                return NotFound("Blog Post not found");
            }

            var postWithTag = new
            {
                BlogId = post.BlogId,
                Title = post.Title,
                SubTitle = post.SubTitle,
                DatePublished = post.DatePublished,
                Body = post.Body,
                Image = post.Image,
                Tags = post.BlogTags.Select(bt => bt.Tag.TagName).ToList()
            };

            return Ok(postWithTag);
        }

        // CREATE BLOG POST
        [HttpPost("create-blog-post")]
        public IActionResult CreatePost([FromForm] CreateBlogPostDto model, IFormFile? image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // create blog entry
            var post = new Blog
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                DatePublished = model.DatePublished,
                Body = model.Body,
            };

            if (image != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.CopyTo(stream);

                    post.Image = stream.ToArray();
                }
            }

            _db.Blogs.Add(post);
            _db.SaveChanges();

            // create blogTag now that we have blog ID
            foreach (var tagId in model.TagIds) 
            {
                var blogTag = new BlogTag
                {
                    BlogId = post.BlogId,
                    TagId = tagId
                };

                _db.BlogTags.Add(blogTag);
            }

             _db.SaveChanges();

            return Ok(post);
        }
    }
}
