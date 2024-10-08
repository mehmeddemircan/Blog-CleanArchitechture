﻿using Application.Constants;
using Application.Features.BlogTags.Commands.Create;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogTags.Validations
{
    public class CreateBlogTagCommandValidator : AbstractValidator<CreateBlogTagCommand>
    {
        public CreateBlogTagCommandValidator()
        {
            RuleFor(x => x.BlogId)
                 .GreaterThan(0).WithMessage(ValidationMessages.BlogIdMustBeGreaterThanZero);

            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage(ValidationMessages.TagIdMustBeGreaterThanZero);
        }
    }
}
