using Application.Features.FAQs.Commands.Update;
using FluentValidation;

namespace Application.Features.FAQs.Validations
{
    public class UpdateFAQCommandValidator : AbstractValidator<UpdateFAQCommand>
    {
        public UpdateFAQCommandValidator()
        {
            RuleFor(f => f.Question)
                .NotEmpty().WithMessage("Question is required.")
                .MaximumLength(200).WithMessage("Question must not exceed 200 characters.");

            RuleFor(f => f.Answer)
                .NotEmpty().WithMessage("Answer is required.")
                .MaximumLength(1000).WithMessage("Answer must not exceed 1000 characters.");
        }
    }
}
