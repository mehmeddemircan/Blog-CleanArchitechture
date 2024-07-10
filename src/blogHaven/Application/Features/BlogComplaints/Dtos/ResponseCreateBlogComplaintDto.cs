namespace Application.Features.BlogComplaints.Dtos
{
    public class ResponseCreateBlogComplaintDto : IDto
    {
        public int BlogId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
    }
}
