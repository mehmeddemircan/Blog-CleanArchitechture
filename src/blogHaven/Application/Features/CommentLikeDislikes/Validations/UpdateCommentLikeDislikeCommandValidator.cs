using Application.Constants;
using Application.Features.CommentLikeDislikes.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentLikeDislikes.Validations
{
    public class UpdateCommentLikeDislikeCommandValidator : AbstractValidator<UpdateCommentLikeDislikeCommand>
    {
        public UpdateCommentLikeDislikeCommandValidator()
        {
            RuleFor(x => x.CommentId)
                .GreaterThan(0).WithMessage(ValidationMessages.CommentIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
