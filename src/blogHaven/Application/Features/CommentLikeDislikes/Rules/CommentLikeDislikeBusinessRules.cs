using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentLikeDislikes.Rules
{
    public class CommentLikeDislikeBusinessRules
    {
        private readonly ICommentLikeDislikeRepository _commentlikedislikeRepository;

        public CommentLikeDislikeBusinessRules(ICommentLikeDislikeRepository commentlikedislikeRepository)
        {
            _commentlikedislikeRepository = commentlikedislikeRepository;
        }

        public void CommentLikeDislikeShouldExistWhenRequested(CommentLikeDislike commentlikedislike)
        {
            if (commentlikedislike == null)
            {
                throw new BusinessException(ExceptionMessages.CommentLikeDislikeShouldExistWhenRequested);
            }
        }
    }
}
