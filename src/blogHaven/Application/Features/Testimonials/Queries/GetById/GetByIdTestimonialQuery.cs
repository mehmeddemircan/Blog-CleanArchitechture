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

namespace Application.Features.Testimonials.Queries.GetById
{
    public class GetByIdTestimonialQuery : IRequest<IDataResult<ResponseTestimonialByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQuery, IDataResult<ResponseTestimonialByIdDto>>
        {
            private readonly ITestimonialRepository _testimonialRepository;
            private readonly IMapper _mapper;
            private readonly TestimonialBusinessRules _testimonialBusinessRules;

            public GetByIdTestimonialQueryHandler(ITestimonialRepository testimonialRepository, IMapper mapper, TestimonialBusinessRules testimonialBusinessRules)
            {
                _testimonialRepository = testimonialRepository;
                _mapper = mapper;
                _testimonialBusinessRules = testimonialBusinessRules;
            }

            public async Task<IDataResult<ResponseTestimonialByIdDto>> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
            {
                Testimonial? testimonial = await _testimonialRepository.GetAsync(b => b.Id == request.Id);

                 _testimonialBusinessRules.TestimonialShouldExistWhenRequested(testimonial);

                ResponseTestimonialByIdDto testimonialGetByIdDto = _mapper.Map<ResponseTestimonialByIdDto>(testimonial);
                return new SuccessDataResult<ResponseTestimonialByIdDto>(testimonialGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
