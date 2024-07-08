
using Application.Features.Categories.Constants;
using Application.Features.Tags.Commands.CreateTag;
using Application.Features.Tags.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Validations
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(TagValidationMessages.TagNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(TagValidationMessages.TagNameMinLength);
        }
    }
}
