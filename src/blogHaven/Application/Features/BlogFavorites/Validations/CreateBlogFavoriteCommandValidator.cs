using Application.Constants;
using Application.Features.BlogFavorites.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogFavorites.Validations
{
    public class CreateBlogFavoriteCommandValidator : AbstractValidator<CreateBlogFavoriteCommand>
    {

        public CreateBlogFavoriteCommandValidator()
        {
            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
