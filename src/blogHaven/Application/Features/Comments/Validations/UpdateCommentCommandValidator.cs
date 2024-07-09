using Application.Constants;
using Application.Features.Comments.Commands.Update;
using FluentValidation;

namespace Application.Features.Comments.Validations
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(ValidationMessages.ContentIsRequired)
                .MaximumLength(500).WithMessage(ValidationMessages.ContentMaxCharacterExceed);

            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }

}
