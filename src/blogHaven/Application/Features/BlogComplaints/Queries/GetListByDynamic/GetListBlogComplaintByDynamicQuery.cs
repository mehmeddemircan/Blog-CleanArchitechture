using Application.Constants;
using Application.Features.BlogComplaints.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace Application.Features.BlogComplaints.Queries.GetListByDynamic
{
    public class GetListBlogComplaintByDynamicQuery : IRequest<IDataResult<ResponseBlogComplaintListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListBlogComplaintByDynamicQueryHandler : IRequestHandler<GetListBlogComplaintByDynamicQuery, IDataResult<ResponseBlogComplaintListModel>>
        {

            private readonly IMapper _mapper;
            private readonly IBlogComplaintRepository _blogcomplaintRepository;

            public GetListBlogComplaintByDynamicQueryHandler(IMapper mapper, IBlogComplaintRepository blogcomplaintRepository)
            {
                _mapper = mapper;
                _blogcomplaintRepository = blogcomplaintRepository;
            }

            public async Task<IDataResult<ResponseBlogComplaintListModel>> Handle(GetListBlogComplaintByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<BlogComplaint> blogcomplaints = await _blogcomplaintRepository.GetListByDynamicAsync(request.Dynamic,
                                              include: query => query.Include(b => b.Complainer).Include(b => b.Blog),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseBlogComplaintListModel mappedBlogComplaints = _mapper.Map<ResponseBlogComplaintListModel>(blogcomplaints);
                return new SuccessDataResult<ResponseBlogComplaintListModel>(mappedBlogComplaints, ResultMessages.Listed);
            }
        }
    }
}
