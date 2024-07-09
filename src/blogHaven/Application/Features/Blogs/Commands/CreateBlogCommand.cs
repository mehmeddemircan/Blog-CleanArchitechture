using Application.Constants;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Rules;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.ImageService;
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

namespace Application.Features.Blogs.Commands
{
    public partial class CreateBlogCommand : IRequest<IDataResult<ResponseCreateBlogDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ThumbNailImage { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IDataResult<ResponseCreateBlogDto>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            private readonly BlogBusinessRules _blogBusinessRules;
            private readonly IImageService _imageService;

            public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper,
                                             BlogBusinessRules blogBusinessRules,IImageService imageService)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
                _blogBusinessRules = blogBusinessRules;
                _imageService = imageService;
            }

            public async Task<IDataResult<ResponseCreateBlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                await _blogBusinessRules.BlogNameCanNotBeDuplicatedWhenInserted(request.Title);

                Blog mappedEntity = _mapper.Map<Blog>(request);
                Blog createBlog = await _blogRepository.AddAsync(mappedEntity);
                ResponseCreateBlogDto createdBlogDto = _mapper.Map<ResponseCreateBlogDto>(createBlog);
                return new SuccessDataResult<ResponseCreateBlogDto>(createdBlogDto, ResultMessages.Added);
            }
        }
    }
}
