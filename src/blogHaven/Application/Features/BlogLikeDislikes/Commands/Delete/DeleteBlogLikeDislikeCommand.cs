using Application.Constants;
using Application.Features.BlogLikeDislikes.Dtos;
using Application.Features.BlogLikeDislikes.Rules;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.BlogLikeDislikes.Commands.Delete
{
    public partial class DeleteBlogLikeDislikeCommand : IRequest<IDataResult<ResponseDeleteBlogLikeDislikeDto>>
    {
        public int Id { get; set; }

        public class DeleteBlogLikeDislikeCommandHandler : IRequestHandler<DeleteBlogLikeDislikeCommand, IDataResult<ResponseDeleteBlogLikeDislikeDto>>
        {
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly BlogLikeDislikeBusinessRules _bloglikedislikeBusinessRules;

            public DeleteBlogLikeDislikeCommandHandler(IBlogLikeDislikeRepository bloglikedislikeRepository, IMapper mapper,
                                             BlogLikeDislikeBusinessRules bloglikedislikeBusinessRules)
            {
                _bloglikedislikeRepository = bloglikedislikeRepository;
                _mapper = mapper;
                _bloglikedislikeBusinessRules = bloglikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteBlogLikeDislikeDto>> Handle(DeleteBlogLikeDislikeCommand request, CancellationToken cancellationToken)
            {
                BlogLikeDislike mappedEntity = _mapper.Map<BlogLikeDislike>(request);
                BlogLikeDislike deleteBlogLikeDislike = await _bloglikedislikeRepository.DeleteAsync(mappedEntity);
                ResponseDeleteBlogLikeDislikeDto deletedBlogLikeDislikeDto = _mapper.Map<ResponseDeleteBlogLikeDislikeDto>(deleteBlogLikeDislike);
                return new SuccessDataResult<ResponseDeleteBlogLikeDislikeDto>(deletedBlogLikeDislikeDto, ResultMessages.Deleted);

            }


        }

    }
}
