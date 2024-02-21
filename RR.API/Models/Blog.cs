using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.API.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime DatePublished { get; set; }
        public string Body { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Image { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }

    }
}
