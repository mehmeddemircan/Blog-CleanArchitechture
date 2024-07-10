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

namespace Application.Features.CommentLikeDislikes.Commands.Create
{
    public partial class CreateCommentLikeDislikeCommand : IRequest<IDataResult<ResponseCreateCommentLikeDislikeDto>>
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }

        public bool IsLiked { get; set; }
        public class CreateCommentLikeDislikeCommandHandler : IRequestHandler<CreateCommentLikeDislikeCommand, IDataResult<ResponseCreateCommentLikeDislikeDto>>
        {
            private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly CommentLikeDislikeBusinessRules _commentlikedislikeBusinessRules;

            public CreateCommentLikeDislikeCommandHandler(ICommentLikeDislikeRepository commentlikedislikeRepository, IMapper mapper,
                                             CommentLikeDislikeBusinessRules commentlikedislikeBusinessRules)
            {
                _commentlikedislikeRepository = commentlikedislikeRepository;
                _mapper = mapper;
                _commentlikedislikeBusinessRules = commentlikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateCommentLikeDislikeDto>> Handle(CreateCommentLikeDislikeCommand request, CancellationToken cancellationToken)
            {



                CommentLikeDislike mappedEntity = _mapper.Map<CommentLikeDislike>(request);
                CommentLikeDislike createCommentLikeDislike = await _commentlikedislikeRepository.AddAsync(mappedEntity);
                ResponseCreateCommentLikeDislikeDto createdCommentLikeDislikeDto = _mapper.Map<ResponseCreateCommentLikeDislikeDto>(createCommentLikeDislike);
                return new SuccessDataResult<ResponseCreateCommentLikeDislikeDto>(createdCommentLikeDislikeDto, ResultMessages.Added);
            }
        }
    }
}
