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

namespace Application.Features.CommentLikeDislikes.Commands.Delete
{
    public partial class DeleteCommentLikeDislikeCommand : IRequest<IDataResult<ResponseDeleteCommentLikeDislikeDto>>
    {
        public int Id { get; set; }

        public class DeleteCommentLikeDislikeCommandHandler : IRequestHandler<DeleteCommentLikeDislikeCommand, IDataResult<ResponseDeleteCommentLikeDislikeDto>>
        {
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly CommentLikeDislikeBusinessRules _commentlikedislikeBusinessRules;

            public DeleteCommentLikeDislikeCommandHandler(ICommentLikeDislikeRepository commentlikedislikeRepository, IMapper mapper,
                                             CommentLikeDislikeBusinessRules commentlikedislikeBusinessRules)
            {
                _commentlikedislikeRepository = commentlikedislikeRepository;
                _mapper = mapper;
                _commentlikedislikeBusinessRules = commentlikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteCommentLikeDislikeDto>> Handle(DeleteCommentLikeDislikeCommand request, CancellationToken cancellationToken)
            {
                CommentLikeDislike mappedEntity = _mapper.Map<CommentLikeDislike>(request);
                CommentLikeDislike deleteCommentLikeDislike = await _commentlikedislikeRepository.DeleteAsync(mappedEntity);
                ResponseDeleteCommentLikeDislikeDto deletedCommentLikeDislikeDto = _mapper.Map<ResponseDeleteCommentLikeDislikeDto>(deleteCommentLikeDislike);
                return new SuccessDataResult<ResponseDeleteCommentLikeDislikeDto>(deletedCommentLikeDislikeDto, ResultMessages.Deleted);

            }


        }

    }
}
