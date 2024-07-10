namespace Application.Features.BlogComplaints.Dtos
{
    public class ResponseUpdateBlogComplaintDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
    }
}
