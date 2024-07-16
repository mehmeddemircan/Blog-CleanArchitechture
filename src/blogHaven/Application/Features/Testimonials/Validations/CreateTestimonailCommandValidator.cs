using Application.Features.Testimonials.Commands.Create;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Validations
{
    public class CreateTestimonailCommandValidator : AbstractValidator<CreateTestimonialCommand>
    {
    
  
            public CreateTestimonailCommandValidator()
            {
                RuleFor(t => t.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

                RuleFor(t => t.Feedback)
                    .NotEmpty().WithMessage("Feedback is required.")
                    .MaximumLength(500).WithMessage("Feedback must not exceed 500 characters.");

                RuleFor(t => t.Date)
                    .NotEmpty().WithMessage("Date is required.")
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");

            }
    }
    
}
