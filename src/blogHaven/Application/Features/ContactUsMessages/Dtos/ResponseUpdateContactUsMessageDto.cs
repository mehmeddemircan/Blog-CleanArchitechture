namespace Application.Features.ContactUsMessages.Dtos
{
    public class ResponseUpdateContactUsMessageDto : IDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
    }
}
