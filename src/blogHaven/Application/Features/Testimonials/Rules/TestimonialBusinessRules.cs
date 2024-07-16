using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Rules
{
    public class TestimonialBusinessRules
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialBusinessRules(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task TestimonialSameCanNotBeDuplicatedWhenInserted(string name, string feedback)
        {
            IPaginate<Testimonial> result = await _testimonialRepository.GetListAsync(b => b.Name == name && b.Feedback == feedback);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.TestimonialNameExists);
            }
        }
        public void TestimonialShouldExistWhenRequested(Testimonial testimonial)
        {
            if (testimonial == null)
            {
                throw new BusinessException(ExceptionMessages.TestimonialShouldExistWhenRequested);
            }
        }
    }
}
