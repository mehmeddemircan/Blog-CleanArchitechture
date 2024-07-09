namespace Application.Features.Comments.Dtos
{
    public class ResponseUpdateCommentDto : IDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }

    }
}
