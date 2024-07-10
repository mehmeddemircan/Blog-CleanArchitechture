using Application.Constants;
using Application.Features.BlogLikeDislikes.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogLikeDislikes.Validations
{
    public class UpdateBlogLikeDislikeCommandValidator : AbstractValidator<UpdateBlogLikeDislikeCommand>
    {
        public UpdateBlogLikeDislikeCommandValidator()
        {
            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
