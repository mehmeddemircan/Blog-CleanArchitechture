
using Application.Constants;
using Application.Features.BlogTags.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogTags.Validations
{
    public class UpdateBlogTagCommandValidator : AbstractValidator<UpdateBlogTagCommand>
    {
        public UpdateBlogTagCommandValidator()
        {
            RuleFor(x => x.BlogId)
                 .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage(ValidationMessages.TagIdMustBeGreaterThanZero);
        }
    }
}
