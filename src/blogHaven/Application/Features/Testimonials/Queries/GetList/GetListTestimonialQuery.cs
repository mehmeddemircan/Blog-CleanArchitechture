using Application.Constants;
using Application.Features.Testimonials.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Queries.GetList
{
    public class GetListTestimonialQuery : IRequest<IDataResult<ResponseTestimonialListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListTestimonialQueryHandler : IRequestHandler<GetListTestimonialQuery, IDataResult<ResponseTestimonialListModel>>
        {
            private readonly ITestimonialRepository _testimonialRepository;
            private readonly IMapper _mapper;

            public GetListTestimonialQueryHandler(ITestimonialRepository testimonialRepository, IMapper mapper)
            {
                _testimonialRepository = testimonialRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseTestimonialListModel>> Handle(GetListTestimonialQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Testimonial> categories = await _testimonialRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ResponseTestimonialListModel mappedTestimonialListModel = _mapper.Map<ResponseTestimonialListModel>(categories);

                return new SuccessDataResult<ResponseTestimonialListModel>(mappedTestimonialListModel, ResultMessages.Listed);
            }
        }
    }
}
