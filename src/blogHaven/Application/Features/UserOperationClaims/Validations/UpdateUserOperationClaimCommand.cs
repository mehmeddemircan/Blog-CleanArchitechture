﻿using Application.Features.UserOperationClaims.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Validations
{
    public class UpdateUserOperationClaimCommandValidator : AbstractValidator<UpdateUserOperationClaimCommand>
    {
        public UpdateUserOperationClaimCommandValidator()
        {
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.OperationClaimId).GreaterThan(0);
        }
    }
}
