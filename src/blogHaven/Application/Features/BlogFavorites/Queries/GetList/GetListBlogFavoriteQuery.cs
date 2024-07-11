using Application.Constants;
using Application.Features.BlogFavorites.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogFavorites.Queries.GetList
{
    public class GetListBlogFavoriteQuery : IRequest<IDataResult<ResponseBlogFavoriteListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBlogFavoriteQueryHandler : IRequestHandler<GetListBlogFavoriteQuery, IDataResult<ResponseBlogFavoriteListModel>>
        {
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;
            private readonly IMapper _mapper;

            public GetListBlogFavoriteQueryHandler(IBlogFavoriteRepository blogfavoriteRepository, IMapper mapper)
            {
                _blogfavoriteRepository = blogfavoriteRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseBlogFavoriteListModel>> Handle(GetListBlogFavoriteQuery request, CancellationToken cancellationToken)
            {
                IPaginate<BlogFavorite> categories = await _blogfavoriteRepository.GetListAsync(

                                   include: source =>
                                                                source.Include(b => b.User)
                                                               .Include(b => b.Blog)
                                                               .ThenInclude(b => b.Category)
                                                                  .Include(b => b.Blog)
                                                               .ThenInclude(b => b.User),

                                                               index: request.PageRequest.Page,
                                                               size: request.PageRequest.PageSize);

                ResponseBlogFavoriteListModel mappedBlogFavoriteListModel = _mapper.Map<ResponseBlogFavoriteListModel>(categories);

                return new SuccessDataResult<ResponseBlogFavoriteListModel>(mappedBlogFavoriteListModel, ResultMessages.Listed);
            }
        }
    }
}
