using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Validations
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(CategoryValidationMessages.CategoryNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(CategoryValidationMessages.CategoryNameMinLength);
        }
    }
}
