namespace Application.Features.Blogs.Dtos
{
    public class ResponseUpdateBlogDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ThumbNailImage { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
