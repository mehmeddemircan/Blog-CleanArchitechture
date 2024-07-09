using Application.Constants;
using Application.Features.Blogs.Models;
using Application.Features.Categories.Models;
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

namespace Application.Features.Blogs.Queries.GetList
{
    public class GetListBlogQuery : IRequest<IDataResult<ResponseBlogListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, IDataResult<ResponseBlogListModel>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;

            public GetListBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseBlogListModel>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Blog> categories = await _blogRepository.GetListAsync(include: source =>
                                                 source.Include(b => b.User)
                                                .Include(b => b.Category)
                                                .Include(b  => b.BlogTags)
                                                    .ThenInclude(bt => bt.Tag),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);

                ResponseBlogListModel mappedBlogListModel = _mapper.Map<ResponseBlogListModel>(categories);

                return new SuccessDataResult<ResponseBlogListModel>(mappedBlogListModel, ResultMessages.Listed);
            }
        }
    }
}
