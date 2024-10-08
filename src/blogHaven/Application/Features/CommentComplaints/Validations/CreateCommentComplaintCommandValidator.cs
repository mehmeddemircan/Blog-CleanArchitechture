﻿using Application.Constants;
using Application.Features.CommentComplaints.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentComplaints.Validations
{
    public class CreateCommentComplaintCommandValidator : AbstractValidator<CreateCommentComplaintCommand>
    {
        public CreateCommentComplaintCommandValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage(ValidationMessages.MessageIsRequired)
                .MaximumLength(500).WithMessage(ValidationMessages.MessageMaxCharacterExceed);

  

            RuleFor(x => x.CommentId)
                .GreaterThan(0).WithMessage(ValidationMessages.CommentIdMustBeGreaterThanZero);

            RuleFor(x => x.ComplainerId)
                .GreaterThan(0).WithMessage(ValidationMessages.UserIdMustBeGreaterThanZero);
        }
    }
}
