using Application.Constants;
using Application.Features.BlogLikeDislikes.Models;
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

namespace Application.Features.BlogLikeDislikes.Queries.GetListByDynamic
{
    public class GetListBlogLikeDislikeByDynamicQuery : IRequest<IDataResult<ResponseBlogLikeDislikeListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListBlogLikeDislikeByDynamicQueryHandler : IRequestHandler<GetListBlogLikeDislikeByDynamicQuery, IDataResult<ResponseBlogLikeDislikeListModel>>
        {

            private readonly IMapper _mapper;
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;

            public GetListBlogLikeDislikeByDynamicQueryHandler(IMapper mapper, IBlogLikeDislikeRepository bloglikedislikeRepository)
            {
                _mapper = mapper;
                _bloglikedislikeRepository = bloglikedislikeRepository;
            }

            public async Task<IDataResult<ResponseBlogLikeDislikeListModel>> Handle(GetListBlogLikeDislikeByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<BlogLikeDislike> bloglikedislikes = await _bloglikedislikeRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              query => query.Include(c => c.User).Include(b => b.Blog),

                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseBlogLikeDislikeListModel mappedBlogLikeDislikes = _mapper.Map<ResponseBlogLikeDislikeListModel>(bloglikedislikes);
                return new SuccessDataResult<ResponseBlogLikeDislikeListModel>(mappedBlogLikeDislikes, ResultMessages.Listed);
            }
        }
    }
}
