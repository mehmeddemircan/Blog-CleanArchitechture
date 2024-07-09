using Application.Constants;
using Application.Features.Blogs.Models;
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

namespace Application.Features.Blogs.Queries.GetListByDynamic
{
    public class GetListBlogByDynamicQuery : IRequest<IDataResult<ResponseBlogListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListBlogByDynamicQueryHandler : IRequestHandler<GetListBlogByDynamicQuery, IDataResult<ResponseBlogListModel>>
        {

            private readonly IMapper _mapper;
            private readonly IBlogRepository _blogRepository;

            public GetListBlogByDynamicQueryHandler(IMapper mapper, IBlogRepository blogRepository)
            {
                _mapper = mapper;
                _blogRepository = blogRepository;
            }

            public async Task<IDataResult<ResponseBlogListModel>> Handle(GetListBlogByDynamicQuery request, CancellationToken cancellationToken)
            {
                
                IPaginate<Blog> blogs = await _blogRepository.GetListByDynamicAsync(request.Dynamic,
                                              include: query => query.Include(b => b.Category).Include(b => b.User),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                
                ResponseBlogListModel mappedBlogs = _mapper.Map<ResponseBlogListModel>(blogs);
                return new SuccessDataResult<ResponseBlogListModel>(mappedBlogs, ResultMessages.Listed);
            }
        }
    }
}
