using Application.Constants;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Rules;
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

namespace Application.Features.Blogs.Queries.GetById
{
    public class GetByIdBlogQuery : IRequest<IDataResult<ResponseBlogByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, IDataResult<ResponseBlogByIdDto>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            private readonly BlogBusinessRules _blogBusinessRules;

            public GetByIdBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper, BlogBusinessRules blogBusinessRules)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
                _blogBusinessRules = blogBusinessRules;
            }

            public async Task<IDataResult<ResponseBlogByIdDto>> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
            {
                Blog? blog = await _blogRepository.GetDetailsAsync(b => b.Id == request.Id,b => b.User,b  => b.Category);

                _blogBusinessRules.BlogShouldExistWhenRequested(blog);

                ResponseBlogByIdDto blogGetByIdDto = _mapper.Map<ResponseBlogByIdDto>(blog);
                return new SuccessDataResult<ResponseBlogByIdDto>(blogGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
