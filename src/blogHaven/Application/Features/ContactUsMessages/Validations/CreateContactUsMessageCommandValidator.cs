using Application.Constants;
using Application.Features.ContactUsMessages.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContactUsMessages.Validations
{
    public class CreateContactUsMessageCommandValidator : AbstractValidator<CreateContactUsMessageCommand>
    {
        public CreateContactUsMessageCommandValidator()
        {
            RuleFor(c => c.Topic).NotEmpty().WithMessage(ValidationMessages.TopicIsRequired).MaximumLength(100).WithMessage(ValidationMessages.TopicMaxCharacterExceed);

            RuleFor(c => c.Content).NotEmpty().WithMessage(ValidationMessages.ContentIsRequired).MaximumLength(500).WithMessage(ValidationMessages.ContentMaxCharacterExceed);
        }
    }
}
