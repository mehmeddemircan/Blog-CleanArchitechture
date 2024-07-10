using Application.Constants;
using Application.Features.BlogComplaints.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Queries.GetList
{
    public class GetListBlogComplaintQuery : IRequest<IDataResult<ResponseBlogComplaintListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBlogComplaintQueryHandler : IRequestHandler<GetListBlogComplaintQuery, IDataResult<ResponseBlogComplaintListModel>>
        {
            private readonly IBlogComplaintRepository _blogcomplaintRepository;
            private readonly IMapper _mapper;

            public GetListBlogComplaintQueryHandler(IBlogComplaintRepository blogcomplaintRepository, IMapper mapper)
            {
                _blogcomplaintRepository = blogcomplaintRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseBlogComplaintListModel>> Handle(GetListBlogComplaintQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BlogComplaint> categories = await _blogcomplaintRepository.GetListAsync(include: source =>
                                                 source.Include(b => b.Complainer)
                                                .Include(b => b.Blog),

                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);

                ResponseBlogComplaintListModel mappedBlogComplaintListModel = _mapper.Map<ResponseBlogComplaintListModel>(categories);

                return new SuccessDataResult<ResponseBlogComplaintListModel>(mappedBlogComplaintListModel, ResultMessages.Listed);
            }
        }
    }
}
