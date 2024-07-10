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

namespace Application.Features.BlogLikeDislikes.Rules
{
    public class BlogLikeDislikeBusinessRules
    {
        private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;

        public BlogLikeDislikeBusinessRules(IBlogLikeDislikeRepository bloglikedislikeRepository)
        {
            _bloglikedislikeRepository = bloglikedislikeRepository;
        }

        public void BlogLikeDislikeShouldExistWhenRequested(BlogLikeDislike bloglikedislike)
        {
            if (bloglikedislike == null)
            {
                throw new BusinessException(ExceptionMessages.BlogLikeDislikeShouldExistWhenRequested);
            }
        }
    }
}
