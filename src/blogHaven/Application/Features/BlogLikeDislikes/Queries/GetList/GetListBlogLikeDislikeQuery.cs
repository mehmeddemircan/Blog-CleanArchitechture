using Application.Constants;
using Application.Features.BlogLikeDislikes.Models;
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

namespace Application.Features.BlogLikeDislikes.Queries.GetList
{
    public class GetListBlogLikeDislikeQuery : IRequest<IDataResult<ResponseBlogLikeDislikeListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBlogLikeDislikeQueryHandler : IRequestHandler<GetListBlogLikeDislikeQuery, IDataResult<ResponseBlogLikeDislikeListModel>>
        {
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;
            private readonly IMapper _mapper;

            public GetListBlogLikeDislikeQueryHandler(IBlogLikeDislikeRepository bloglikedislikeRepository, IMapper mapper)
            {
                _bloglikedislikeRepository = bloglikedislikeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseBlogLikeDislikeListModel>> Handle(GetListBlogLikeDislikeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BlogLikeDislike> categories = await _bloglikedislikeRepository.GetListAsync(

                                   include: source =>
                                                                source.Include(b => b.User)
                                                               .Include(b => b.Blog),
                                                               index: request.PageRequest.Page,
                                                               size: request.PageRequest.PageSize);

                ResponseBlogLikeDislikeListModel mappedBlogLikeDislikeListModel = _mapper.Map<ResponseBlogLikeDislikeListModel>(categories);

                return new SuccessDataResult<ResponseBlogLikeDislikeListModel>(mappedBlogLikeDislikeListModel, ResultMessages.Listed);
            }
        }
    }
}
