using Application.Constants;
using Application.Features.Categories.Commands.CreateCategory;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Validations
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.CategoryNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(ValidationMessages.CategoryNameMinLength);
        }
    }
}
