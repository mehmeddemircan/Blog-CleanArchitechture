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

namespace Application.Features.BlogFavorites.Commands.Update
{
    public partial class UpdateBlogFavoriteCommand : IRequest<IDataResult<ResponseUpdateBlogFavoriteDto>>
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsFavorite { get; set; }
        public class UpdateBlogFavoriteCommandHandler : IRequestHandler<UpdateBlogFavoriteCommand, IDataResult<ResponseUpdateBlogFavoriteDto>>
        {
            private readonly IBlogFavoriteRepository _blogfavoriteRepository;
            private readonly IMapper _mapper;
            private readonly BlogFavoriteBusinessRules _blogfavoriteBusinessRules;

            public UpdateBlogFavoriteCommandHandler(IBlogFavoriteRepository blogfavoriteRepository, IMapper mapper,
                                             BlogFavoriteBusinessRules blogfavoriteBusinessRules)
            {
                _blogfavoriteRepository = blogfavoriteRepository;
                _mapper = mapper;
                _blogfavoriteBusinessRules = blogfavoriteBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateBlogFavoriteDto>> Handle(UpdateBlogFavoriteCommand request, CancellationToken cancellationToken)
            {

                BlogFavorite mappedEntity = _mapper.Map<BlogFavorite>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                BlogFavorite updateBlogFavorite = await _blogfavoriteRepository.UpdateAsync(mappedEntity);
                ResponseUpdateBlogFavoriteDto updatedBlogFavoriteDto = _mapper.Map<ResponseUpdateBlogFavoriteDto>(updateBlogFavorite);
                return new SuccessDataResult<ResponseUpdateBlogFavoriteDto>(updatedBlogFavoriteDto, ResultMessages.Added);
            }
        }
    }
}
