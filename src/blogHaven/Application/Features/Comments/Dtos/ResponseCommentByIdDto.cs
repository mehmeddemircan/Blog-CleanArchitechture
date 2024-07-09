namespace Application.Features.Comments.Dtos
{
    public class ResponseCommentByIdDto : IDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }
}
