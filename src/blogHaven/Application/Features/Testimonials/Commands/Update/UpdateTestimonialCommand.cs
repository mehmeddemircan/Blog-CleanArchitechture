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

namespace Application.Features.Testimonials.Commands.Update
{
    public partial class UpdateTestimonialCommand : IRequest<IDataResult<ResponseUpdateTestimonialDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Feedback { get; set; }

        public DateTime Date { get; set; }

        public string? PhotoUrl { get; set; }

        public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, IDataResult<ResponseUpdateTestimonialDto>>
        {
            private readonly ITestimonialRepository _testimonialRepository;
            private readonly IMapper _mapper;
            private readonly TestimonialBusinessRules _testimonialBusinessRules;

            public UpdateTestimonialCommandHandler(ITestimonialRepository testimonialRepository, IMapper mapper,
                                             TestimonialBusinessRules testimonialBusinessRules)
            {
                _testimonialRepository = testimonialRepository;
                _mapper = mapper;
                _testimonialBusinessRules = testimonialBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateTestimonialDto>> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
            {
                await _testimonialBusinessRules.TestimonialSameCanNotBeDuplicatedWhenInserted(request.Name,request.Feedback);


                Testimonial mappedEntity = _mapper.Map<Testimonial>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Testimonial updateTestimonial = await _testimonialRepository.UpdateAsync(mappedEntity);
                ResponseUpdateTestimonialDto updatedTestimonialDto = _mapper.Map<ResponseUpdateTestimonialDto>(updateTestimonial);
                return new SuccessDataResult<ResponseUpdateTestimonialDto>(updatedTestimonialDto, ResultMessages.Updated);
            }
        }
    }
}
