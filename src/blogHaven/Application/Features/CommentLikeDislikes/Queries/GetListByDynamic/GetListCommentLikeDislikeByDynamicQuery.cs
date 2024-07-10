using Application.Constants;
using Application.Features.CommentLikeDislikes.Models;
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

namespace Application.Features.CommentLikeDislikes.Queries.GetListByDynamic
{
    public class GetListCommentLikeDislikeByDynamicQuery : IRequest<IDataResult<ResponseCommentLikeDislikeListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListCommentLikeDislikeByDynamicQueryHandler : IRequestHandler<GetListCommentLikeDislikeByDynamicQuery, IDataResult<ResponseCommentLikeDislikeListModel>>
        {

            private readonly IMapper _mapper;
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;

            public GetListCommentLikeDislikeByDynamicQueryHandler(IMapper mapper, ICommentLikeDislikeRepository commentlikedislikeRepository)
            {
                _mapper = mapper;
                _commentlikedislikeRepository = commentlikedislikeRepository;
            }

            public async Task<IDataResult<ResponseCommentLikeDislikeListModel>> Handle(GetListCommentLikeDislikeByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<CommentLikeDislike> commentlikedislikes = await _commentlikedislikeRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              query => query.Include(c => c.User).Include(b => b.Comment),

                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseCommentLikeDislikeListModel mappedCommentLikeDislikes = _mapper.Map<ResponseCommentLikeDislikeListModel>(commentlikedislikes);
                return new SuccessDataResult<ResponseCommentLikeDislikeListModel>(mappedCommentLikeDislikes, ResultMessages.Listed);
            }
        }
    }
}
