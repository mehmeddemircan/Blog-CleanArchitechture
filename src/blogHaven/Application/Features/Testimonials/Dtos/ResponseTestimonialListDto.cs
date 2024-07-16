namespace Application.Features.Testimonials.Dtos
{
    public class ResponseTestimonialListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Feedback { get; set; }

        public DateTime Date { get; set; }

        public string? PhotoUrl { get; set; }
    }
}
