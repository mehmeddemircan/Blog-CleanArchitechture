using Application.Constants;
using Application.Features.BlogFavorites.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace Application.Features.BlogFavorites.Queries.GetListByDynamic
{
    public class GetListBlogFavoriteByDynamicQuery : IRequest<IDataResult<ResponseBlogFavoriteListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListBlogFavoriteByDynamicQueryHandler : IRequestHandler<GetListBlogFavoriteByDynamicQuery, IDataResult<ResponseBlogFavoriteListModel>>
        {

            private readonly IMapper _mapper;
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;

            public GetListBlogFavoriteByDynamicQueryHandler(IMapper mapper, IBlogFavoriteRepository blogfavoriteRepository)
            {
                _mapper = mapper;
                _blogfavoriteRepository = blogfavoriteRepository;
            }

            public async Task<IDataResult<ResponseBlogFavoriteListModel>> Handle(GetListBlogFavoriteByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<BlogFavorite> blogfavorites = await _blogfavoriteRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              query => query.Include(c => c.User).Include(b => b.Blog),

                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseBlogFavoriteListModel mappedBlogFavorites = _mapper.Map<ResponseBlogFavoriteListModel>(blogfavorites);
                return new SuccessDataResult<ResponseBlogFavoriteListModel>(mappedBlogFavorites, ResultMessages.Listed);
            }
        }
    }
}
