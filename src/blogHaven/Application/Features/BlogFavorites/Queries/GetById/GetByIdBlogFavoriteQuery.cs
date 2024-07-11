using Application.Constants;
using Application.Features.BlogFavorites.Dtos;
using Application.Features.BlogFavorites.Rules;
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

namespace Application.Features.BlogFavorites.Queries.GetById
{
    public class GetByIdBlogFavoriteQuery : IRequest<IDataResult<ResponseBlogFavoriteByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdBlogFavoriteQueryHandler : IRequestHandler<GetByIdBlogFavoriteQuery, IDataResult<ResponseBlogFavoriteByIdDto>>
        {
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;
            private readonly IMapper _mapper;
            private readonly BlogFavoriteBusinessRules _blogfavoriteBusinessRules;

            public GetByIdBlogFavoriteQueryHandler(IBlogFavoriteRepository blogfavoriteRepository, IMapper mapper, BlogFavoriteBusinessRules blogfavoriteBusinessRules)
            {
                _blogfavoriteRepository = blogfavoriteRepository;
                _mapper = mapper;
                _blogfavoriteBusinessRules = blogfavoriteBusinessRules;
            }

            public async Task<IDataResult<ResponseBlogFavoriteByIdDto>> Handle(GetByIdBlogFavoriteQuery request, CancellationToken cancellationToken)
            {
                BlogFavorite? blogfavorite = await _blogfavoriteRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Blog, b => b.User,b => b.Blog.User,b => b.Blog.Category);

                _blogfavoriteBusinessRules.BlogFavoriteShouldExistWhenRequested(blogfavorite);

                ResponseBlogFavoriteByIdDto blogfavoriteGetByIdDto = _mapper.Map<ResponseBlogFavoriteByIdDto>(blogfavorite);
                return new SuccessDataResult<ResponseBlogFavoriteByIdDto>(blogfavoriteGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
