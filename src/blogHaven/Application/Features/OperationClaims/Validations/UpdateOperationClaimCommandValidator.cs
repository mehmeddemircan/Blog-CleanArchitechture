using Application.Constants;
using Application.Features.OperationClaims.Commands.Update;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Validations
{
    public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.TagNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(ValidationMessages.TagNameMinLength);
        }
    }
}
