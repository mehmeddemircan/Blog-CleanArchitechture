using Application.Constants;
using Application.Features.CommentLikeDislikes.Dtos;
using Application.Features.CommentLikeDislikes.Rules;
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

namespace Application.Features.CommentLikeDislikes.Queries.GetById
{
    public class GetByIdCommentLikeDislikeQuery : IRequest<IDataResult<ResponseCommentLikeDislikeByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdCommentLikeDislikeQueryHandler : IRequestHandler<GetByIdCommentLikeDislikeQuery, IDataResult<ResponseCommentLikeDislikeByIdDto>>
        {
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly CommentLikeDislikeBusinessRules _commentlikedislikeBusinessRules;

            public GetByIdCommentLikeDislikeQueryHandler(ICommentLikeDislikeRepository commentlikedislikeRepository, IMapper mapper, CommentLikeDislikeBusinessRules commentlikedislikeBusinessRules)
            {
                _commentlikedislikeRepository = commentlikedislikeRepository;
                _mapper = mapper;
                _commentlikedislikeBusinessRules = commentlikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseCommentLikeDislikeByIdDto>> Handle(GetByIdCommentLikeDislikeQuery request, CancellationToken cancellationToken)
            {
                CommentLikeDislike? commentlikedislike = await _commentlikedislikeRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Comment, b => b.User);

                _commentlikedislikeBusinessRules.CommentLikeDislikeShouldExistWhenRequested(commentlikedislike);

                ResponseCommentLikeDislikeByIdDto commentlikedislikeGetByIdDto = _mapper.Map<ResponseCommentLikeDislikeByIdDto>(commentlikedislike);
                return new SuccessDataResult<ResponseCommentLikeDislikeByIdDto>(commentlikedislikeGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
