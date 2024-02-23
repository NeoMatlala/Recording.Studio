using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.API.DTOs
{
    public class CreateBlogPostDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime DatePublished { get; set; }
        public string Body { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Image { get; set; }
        public int[] TagIds { get; set; }
    }
}
