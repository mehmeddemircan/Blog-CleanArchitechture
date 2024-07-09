namespace Application.Features.ContactUsMessages.Dtos
{
    public class ResponseContactUsMessageByIdDto : IDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
