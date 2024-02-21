namespace RR.API.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
