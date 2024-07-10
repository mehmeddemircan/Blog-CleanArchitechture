namespace Application.Features.CommentComplaints.Dtos
{
    public class ResponseUpdateCommentComplaintDto : IDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
    }

}
