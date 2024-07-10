using Application.Constants;
using Application.Features.BlogLikeDislikes.Dtos;
using Application.Features.BlogLikeDislikes.Rules;
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

namespace Application.Features.BlogLikeDislikes.Commands.Update
{
    public partial class UpdateBlogLikeDislikeCommand : IRequest<IDataResult<ResponseUpdateBlogLikeDislikeDto>>
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }

        public bool IsLiked { get; set; }
        public class UpdateBlogLikeDislikeCommandHandler : IRequestHandler<UpdateBlogLikeDislikeCommand, IDataResult<ResponseUpdateBlogLikeDislikeDto>>
        {
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly BlogLikeDislikeBusinessRules _bloglikedislikeBusinessRules;

            public UpdateBlogLikeDislikeCommandHandler(IBlogLikeDislikeRepository bloglikedislikeRepository, IMapper mapper,
                                             BlogLikeDislikeBusinessRules bloglikedislikeBusinessRules)
            {
                _bloglikedislikeRepository = bloglikedislikeRepository;
                _mapper = mapper;
                _bloglikedislikeBusinessRules = bloglikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateBlogLikeDislikeDto>> Handle(UpdateBlogLikeDislikeCommand request, CancellationToken cancellationToken)
            {

                BlogLikeDislike mappedEntity = _mapper.Map<BlogLikeDislike>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                BlogLikeDislike updateBlogLikeDislike = await _bloglikedislikeRepository.UpdateAsync(mappedEntity);
                ResponseUpdateBlogLikeDislikeDto updatedBlogLikeDislikeDto = _mapper.Map<ResponseUpdateBlogLikeDislikeDto>(updateBlogLikeDislike);
                return new SuccessDataResult<ResponseUpdateBlogLikeDislikeDto>(updatedBlogLikeDislikeDto, ResultMessages.Added);
            }
        }
    }
}
