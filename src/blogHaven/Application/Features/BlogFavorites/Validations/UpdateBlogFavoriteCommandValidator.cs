using Application.Constants;
using Application.Features.BlogFavorites.Commands.Update;
using FluentValidation;

namespace Application.Features.BlogFavorites.Validations
{
    public class UpdateBlogFavoriteCommandValidator : AbstractValidator<UpdateBlogFavoriteCommand>
    {

        public UpdateBlogFavoriteCommandValidator()
        {
            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
