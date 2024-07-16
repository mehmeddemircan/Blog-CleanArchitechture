using Application.Features.FAQs.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FAQs.Validations
{
    public class CreateFAQCommandValidator : AbstractValidator<CreateFAQCommand>
    {
        public CreateFAQCommandValidator()
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
