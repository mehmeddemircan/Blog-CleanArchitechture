namespace Application.Features.CommentComplaints.Dtos
{
    public class ResponseCommentComplaintByIdDto : IDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int ComplainerId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
    }

}
