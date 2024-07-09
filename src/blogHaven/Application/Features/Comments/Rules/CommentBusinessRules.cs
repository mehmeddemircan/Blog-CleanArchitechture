using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Rules
{
    public class CommentBusinessRules
    {
        private readonly ICommentRepository _commentRepository;

        public CommentBusinessRules(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task OneUserCanAddFiveCommentToSameBlog(int blogId, int userId)
        {
            IPaginate<Comment> result = await _commentRepository.GetListAsync(b => b.BlogId == blogId && b.UserId == userId);
            if (result.Items.Count > 4)
            {
                throw new BusinessException(ExceptionMessages.OneUserCanAddFiveComment);
            }
        }

        public void CommentShouldExistWhenRequested(Comment comment)
        {
            if (comment == null)
            {
                throw new BusinessException(ExceptionMessages.CommentShouldExistWhenRequested);
            }
        }
    }
}
