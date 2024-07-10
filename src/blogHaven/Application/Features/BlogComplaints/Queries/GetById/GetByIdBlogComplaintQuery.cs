using Application.Constants;
using Application.Features.BlogComplaints.Dtos;
using Application.Features.BlogComplaints.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Queries.GetById
{
    public class GetByIdBlogComplaintQuery : IRequest<IDataResult<ResponseBlogComplaintByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdBlogComplaintQueryHandler : IRequestHandler<GetByIdBlogComplaintQuery, IDataResult<ResponseBlogComplaintByIdDto>>
        {
            private readonly IBlogComplaintRepository _blogcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly BlogComplaintBusinessRules _blogcomplaintBusinessRules;

            public GetByIdBlogComplaintQueryHandler(IBlogComplaintRepository blogcomplaintRepository, IMapper mapper, BlogComplaintBusinessRules blogcomplaintBusinessRules)
            {
                _blogcomplaintRepository = blogcomplaintRepository;
                _mapper = mapper;
                _blogcomplaintBusinessRules = blogcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseBlogComplaintByIdDto>> Handle(GetByIdBlogComplaintQuery request, CancellationToken cancellationToken)
            {
                BlogComplaint? blogcomplaint = await _blogcomplaintRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Complainer, b => b.Blog);

                _blogcomplaintBusinessRules.BlogComplaintShouldExistWhenRequested(blogcomplaint);

                ResponseBlogComplaintByIdDto blogcomplaintGetByIdDto = _mapper.Map<ResponseBlogComplaintByIdDto>(blogcomplaint);
                return new SuccessDataResult<ResponseBlogComplaintByIdDto>(blogcomplaintGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
