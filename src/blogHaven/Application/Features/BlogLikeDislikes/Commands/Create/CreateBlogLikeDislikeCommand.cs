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

namespace Application.Features.BlogLikeDislikes.Commands.Create
{
    public partial class CreateBlogLikeDislikeCommand : IRequest<IDataResult<ResponseCreateBlogLikeDislikeDto>>
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }

        public bool IsLiked { get; set; }
        public class CreateBlogLikeDislikeCommandHandler : IRequestHandler<CreateBlogLikeDislikeCommand, IDataResult<ResponseCreateBlogLikeDislikeDto>>
        {
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly BlogLikeDislikeBusinessRules _bloglikedislikeBusinessRules;

            public CreateBlogLikeDislikeCommandHandler(IBlogLikeDislikeRepository bloglikedislikeRepository, IMapper mapper,
                                             BlogLikeDislikeBusinessRules bloglikedislikeBusinessRules)
            {
                _bloglikedislikeRepository = bloglikedislikeRepository;
                _mapper = mapper;
                _bloglikedislikeBusinessRules = bloglikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateBlogLikeDislikeDto>> Handle(CreateBlogLikeDislikeCommand request, CancellationToken cancellationToken)
            {
                


                BlogLikeDislike mappedEntity = _mapper.Map<BlogLikeDislike>(request);
                BlogLikeDislike createBlogLikeDislike = await _bloglikedislikeRepository.AddAsync(mappedEntity);
                ResponseCreateBlogLikeDislikeDto createdBlogLikeDislikeDto = _mapper.Map<ResponseCreateBlogLikeDislikeDto>(createBlogLikeDislike);
                return new SuccessDataResult<ResponseCreateBlogLikeDislikeDto>(createdBlogLikeDislikeDto, ResultMessages.Added);
            }
        }
    }
}
