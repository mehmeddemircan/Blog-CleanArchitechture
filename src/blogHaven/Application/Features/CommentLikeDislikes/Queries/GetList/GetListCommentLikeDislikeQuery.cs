using Application.Constants;
using Application.Features.CommentLikeDislikes.Models;
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

namespace Application.Features.CommentLikeDislikes.Queries.GetList
{
    public class GetListCommentLikeDislikeQuery : IRequest<IDataResult<ResponseCommentLikeDislikeListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCommentLikeDislikeQueryHandler : IRequestHandler<GetListCommentLikeDislikeQuery, IDataResult<ResponseCommentLikeDislikeListModel>>
        {
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;
            private readonly IMapper _mapper;

            public GetListCommentLikeDislikeQueryHandler(ICommentLikeDislikeRepository commentlikedislikeRepository, IMapper mapper)
            {
                _commentlikedislikeRepository = commentlikedislikeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseCommentLikeDislikeListModel>> Handle(GetListCommentLikeDislikeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CommentLikeDislike> categories = await _commentlikedislikeRepository.GetListAsync(

                                   include: source =>
                                                                source.Include(b => b.User)
                                                               .Include(b => b.Comment),
                                                               index: request.PageRequest.Page,
                                                               size: request.PageRequest.PageSize);

                ResponseCommentLikeDislikeListModel mappedCommentLikeDislikeListModel = _mapper.Map<ResponseCommentLikeDislikeListModel>(categories);

                return new SuccessDataResult<ResponseCommentLikeDislikeListModel>(mappedCommentLikeDislikeListModel, ResultMessages.Listed);
            }
        }
    }
}
