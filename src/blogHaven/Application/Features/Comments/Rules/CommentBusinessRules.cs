using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
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

       

        public void CommentShouldExistWhenRequested(Comment comment)
        {
            if (comment == null)
            {
                throw new BusinessException(ExceptionMessages.CommentShouldExistWhenRequested);
            }
        }
    }
}
