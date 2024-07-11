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

namespace Application.Features.BlogFavorites.Commands.Delete
{
    public partial class DeleteBlogFavoriteCommand : IRequest<IDataResult<ResponseDeleteBlogFavoriteDto>>
    {
        public int Id { get; set; }

        public class DeleteBlogFavoriteCommandHandler : IRequestHandler<DeleteBlogFavoriteCommand, IDataResult<ResponseDeleteBlogFavoriteDto>>
        {
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;
            private readonly IMapper _mapper;
            private readonly BlogFavoriteBusinessRules _blogfavoriteBusinessRules;

            public DeleteBlogFavoriteCommandHandler(IBlogFavoriteRepository blogfavoriteRepository, IMapper mapper,
                                             BlogFavoriteBusinessRules blogfavoriteBusinessRules)
            {
                _blogfavoriteRepository = blogfavoriteRepository;
                _mapper = mapper;
                _blogfavoriteBusinessRules = blogfavoriteBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteBlogFavoriteDto>> Handle(DeleteBlogFavoriteCommand request, CancellationToken cancellationToken)
            {
                BlogFavorite mappedEntity = _mapper.Map<BlogFavorite>(request);
                BlogFavorite deleteBlogFavorite = await _blogfavoriteRepository.DeleteAsync(mappedEntity);
                ResponseDeleteBlogFavoriteDto deletedBlogFavoriteDto = _mapper.Map<ResponseDeleteBlogFavoriteDto>(deleteBlogFavorite);
                return new SuccessDataResult<ResponseDeleteBlogFavoriteDto>(deletedBlogFavoriteDto, ResultMessages.Deleted);

            }


        }

    }
}
