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

namespace Application.Features.Testimonials.Commands.Delete
{
    public partial class DeleteTestimonialCommand : IRequest<IDataResult<ResponseDeleteTestimonialDto>>
    {
        public int Id { get; set; }

        public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand, IDataResult<ResponseDeleteTestimonialDto>>
        {
            private readonly ITestimonialRepository _testimonialRepository;
            private readonly IMapper _mapper;
            private readonly TestimonialBusinessRules _testimonialBusinessRules;

            public DeleteTestimonialCommandHandler(ITestimonialRepository testimonialRepository, IMapper mapper,
                                             TestimonialBusinessRules testimonialBusinessRules)
            {
                _testimonialRepository = testimonialRepository;
                _mapper = mapper;
                _testimonialBusinessRules = testimonialBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteTestimonialDto>> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
            {
                Testimonial mappedEntity = _mapper.Map<Testimonial>(request);
                Testimonial deleteTestimonial = await _testimonialRepository.DeleteAsync(mappedEntity);
                ResponseDeleteTestimonialDto deletedTestimonialDto = _mapper.Map<ResponseDeleteTestimonialDto>(deleteTestimonial);
                return new SuccessDataResult<ResponseDeleteTestimonialDto>(deletedTestimonialDto, ResultMessages.Deleted);

            }


        }

    }
}
