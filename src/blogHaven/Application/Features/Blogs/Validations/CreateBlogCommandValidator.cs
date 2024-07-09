using Application.Constants;
using Application.Features.Blogs.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Validations
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.TitleIsRequired)
                .MaximumLength(255).WithMessage(ValidationMessages.TitleMaxCharacterExceed);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationMessages.DescriptionIsRequired)
                .MaximumLength(500).WithMessage(ValidationMessages.DescriptionMaxCharacterExceed);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(ValidationMessages.ContentIsRequired);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage(ValidationMessages.CategoryIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
