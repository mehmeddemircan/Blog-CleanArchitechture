using Application.Constants;
using Application.Features.Testimonials.Dtos;
using Application.Features.Testimonials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Commands.Create
{
    public partial class CreateTestimonialCommand : IRequest<IDataResult<ResponseCreateTestimonialDto>>
    {

        public string Name { get; set; }

        public string Feedback { get; set; }

        public DateTime Date { get; set; }

        public string? PhotoUrl { get; set; }

        public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand, IDataResult<ResponseCreateTestimonialDto>>
        {
            private readonly ITestimonialRepository _testimonialRepository;
            private readonly IMapper _mapper;
            private readonly TestimonialBusinessRules _testimonialBusinessRules;

            public CreateTestimonialCommandHandler(ITestimonialRepository testimonialRepository, IMapper mapper,
                                             TestimonialBusinessRules testimonialBusinessRules)
            {
                _testimonialRepository = testimonialRepository;
                _mapper = mapper;
                _testimonialBusinessRules = testimonialBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateTestimonialDto>> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
            {
                await _testimonialBusinessRules.TestimonialSameCanNotBeDuplicatedWhenInserted(request.Name, request.Feedback);


                Testimonial mappedEntity = _mapper.Map<Testimonial>(request);
                Testimonial createTestimonial = await _testimonialRepository.AddAsync(mappedEntity);
                ResponseCreateTestimonialDto createdTestimonialDto = _mapper.Map<ResponseCreateTestimonialDto>(createTestimonial);
                return new SuccessDataResult<ResponseCreateTestimonialDto>(createdTestimonialDto, ResultMessages.Added);
            }
        }
    }
}
