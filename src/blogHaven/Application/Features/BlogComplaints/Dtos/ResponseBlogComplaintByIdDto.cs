namespace Application.Features.BlogComplaints.Dtos
{
    public class ResponseBlogComplaintByIdDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int ComplainerId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Message { get; set; }
    }
}
