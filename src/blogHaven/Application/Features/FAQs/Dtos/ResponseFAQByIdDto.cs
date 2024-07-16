namespace Application.Features.FAQs.Dtos
{
    public class ResponseFAQByIdDto : IDto
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public string? QuestionPhoto { get; set; }

        public string Answer { get; set; }

        public string? AnswerPhoto { get; set; }
    }
}
