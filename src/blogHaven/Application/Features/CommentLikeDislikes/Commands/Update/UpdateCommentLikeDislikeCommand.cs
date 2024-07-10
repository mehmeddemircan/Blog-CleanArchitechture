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

namespace Application.Features.CommentLikeDislikes.Commands.Update
{
    public partial class UpdateCommentLikeDislikeCommand : IRequest<IDataResult<ResponseUpdateCommentLikeDislikeDto>>
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }

        public bool IsLiked { get; set; }
        public class UpdateCommentLikeDislikeCommandHandler : IRequestHandler<UpdateCommentLikeDislikeCommand, IDataResult<ResponseUpdateCommentLikeDislikeDto>>
        {
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly CommentLikeDislikeBusinessRules _commentlikedislikeBusinessRules;

            public UpdateCommentLikeDislikeCommandHandler(ICommentLikeDislikeRepository commentlikedislikeRepository, IMapper mapper,
                                             CommentLikeDislikeBusinessRules commentlikedislikeBusinessRules)
            {
                _commentlikedislikeRepository = commentlikedislikeRepository;
                _mapper = mapper;
                _commentlikedislikeBusinessRules = commentlikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateCommentLikeDislikeDto>> Handle(UpdateCommentLikeDislikeCommand request, CancellationToken cancellationToken)
            {

                CommentLikeDislike mappedEntity = _mapper.Map<CommentLikeDislike>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                CommentLikeDislike updateCommentLikeDislike = await _commentlikedislikeRepository.UpdateAsync(mappedEntity);
                ResponseUpdateCommentLikeDislikeDto updatedCommentLikeDislikeDto = _mapper.Map<ResponseUpdateCommentLikeDislikeDto>(updateCommentLikeDislike);
                return new SuccessDataResult<ResponseUpdateCommentLikeDislikeDto>(updatedCommentLikeDislikeDto, ResultMessages.Added);
            }
        }
    }
}
