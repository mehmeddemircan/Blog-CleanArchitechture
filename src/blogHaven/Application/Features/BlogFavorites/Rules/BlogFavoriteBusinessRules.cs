using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogFavorites.Rules
{
    public class BlogFavoriteBusinessRules
    {
        private readonly IBlogFavoriteRepository _blogfavoriteRepository;

        public BlogFavoriteBusinessRules(IBlogFavoriteRepository blogfavoriteRepository)
        {
            _blogfavoriteRepository = blogfavoriteRepository;
        }

        public void BlogFavoriteShouldExistWhenRequested(BlogFavorite blogfavorite)
        {
            if (blogfavorite == null)
            {
                throw new BusinessException(ExceptionMessages.BlogFavoriteShouldExistWhenRequested);
            }
        }
    }
}
