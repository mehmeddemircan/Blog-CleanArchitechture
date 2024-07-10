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

namespace Application.Features.BlogLikeDislikes.Queries.GetById
{
   public class GetByIdBlogLikeDislikeQuery : IRequest<IDataResult<ResponseBlogLikeDislikeByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdBlogLikeDislikeQueryHandler : IRequestHandler<GetByIdBlogLikeDislikeQuery, IDataResult<ResponseBlogLikeDislikeByIdDto>>
        {
            private readonly IBlogLikeDislikeRepository _bloglikedislikeRepository;
            private readonly IMapper _mapper;
            private readonly BlogLikeDislikeBusinessRules _bloglikedislikeBusinessRules;

            public GetByIdBlogLikeDislikeQueryHandler(IBlogLikeDislikeRepository bloglikedislikeRepository, IMapper mapper, BlogLikeDislikeBusinessRules bloglikedislikeBusinessRules)
            {
                _bloglikedislikeRepository = bloglikedislikeRepository;
                _mapper = mapper;
                _bloglikedislikeBusinessRules = bloglikedislikeBusinessRules;
            }

            public async Task<IDataResult<ResponseBlogLikeDislikeByIdDto>> Handle(GetByIdBlogLikeDislikeQuery request, CancellationToken cancellationToken)
            {
                BlogLikeDislike? bloglikedislike = await _bloglikedislikeRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Blog,b => b.User);

                _bloglikedislikeBusinessRules.BlogLikeDislikeShouldExistWhenRequested(bloglikedislike);

                ResponseBlogLikeDislikeByIdDto bloglikedislikeGetByIdDto = _mapper.Map<ResponseBlogLikeDislikeByIdDto>(bloglikedislike);
                return new SuccessDataResult<ResponseBlogLikeDislikeByIdDto>(bloglikedislikeGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
