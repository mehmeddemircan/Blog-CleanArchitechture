namespace Application.Features.CommentComplaints.Dtos
{
    public class ResponseCreateCommentComplaintDto : IDto
    {
        public int CommentId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
    }

}
