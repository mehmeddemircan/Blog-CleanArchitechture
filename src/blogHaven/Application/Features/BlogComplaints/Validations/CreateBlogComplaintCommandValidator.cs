using Application.Constants;
using Application.Features.BlogComplaints.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Validations
{
    public class CreateBlogComplaintCommandValidator : AbstractValidator<CreateBlogComplaintCommand>
    {
        public CreateBlogComplaintCommandValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage(ValidationMessages.MessageIsRequired)
                .MaximumLength(500).WithMessage(ValidationMessages.MessageMaxCharacterExceed);



            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.ComplainerId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
