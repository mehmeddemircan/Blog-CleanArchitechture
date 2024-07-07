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
            RuleFor(c => c.Name).NotEmpty().WithMessage("asddas");
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
