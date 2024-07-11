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

namespace Application.Features.BlogFavorites.Commands.Create
{
    public partial class CreateBlogFavoriteCommand : IRequest<IDataResult<ResponseCreateBlogFavoriteDto>>
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsFavorite { get; set; }
        public class CreateBlogFavoriteCommandHandler : IRequestHandler<CreateBlogFavoriteCommand, IDataResult<ResponseCreateBlogFavoriteDto>>
        {
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;
            private readonly IMapper _mapper;
            private readonly BlogFavoriteBusinessRules _blogfavoriteBusinessRules;

            public CreateBlogFavoriteCommandHandler(IBlogFavoriteRepository blogfavoriteRepository, IMapper mapper,
                                             BlogFavoriteBusinessRules blogfavoriteBusinessRules)
            {
                _blogfavoriteRepository = blogfavoriteRepository;
                _mapper = mapper;
                _blogfavoriteBusinessRules = blogfavoriteBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateBlogFavoriteDto>> Handle(CreateBlogFavoriteCommand request, CancellationToken cancellationToken)
            {

                BlogFavorite mappedEntity = _mapper.Map<BlogFavorite>(request);
                BlogFavorite createBlogFavorite = await _blogfavoriteRepository.AddAsync(mappedEntity);
                ResponseCreateBlogFavoriteDto createdBlogFavoriteDto = _mapper.Map<ResponseCreateBlogFavoriteDto>(createBlogFavorite);
                return new SuccessDataResult<ResponseCreateBlogFavoriteDto>(createdBlogFavoriteDto, ResultMessages.Added);
            }
        }
    }
}
