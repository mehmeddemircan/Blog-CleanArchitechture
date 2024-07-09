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

namespace Application.Features.Blogs.Commands.Update
{
    public partial class UpdateBlogCommand : IRequest<IDataResult<ResponseUpdateBlogDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ThumbNailImage { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IDataResult<ResponseUpdateBlogDto>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            private readonly BlogBusinessRules _blogBusinessRules;

            public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper,
                                             BlogBusinessRules blogBusinessRules)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
                _blogBusinessRules = blogBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateBlogDto>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                await _blogBusinessRules.BlogNameCanNotBeDuplicatedWhenInserted(request.Title);


                Blog mappedEntity = _mapper.Map<Blog>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Blog updateBlog = await _blogRepository.UpdateAsync(mappedEntity);
                ResponseUpdateBlogDto updatedBlogDto = _mapper.Map<ResponseUpdateBlogDto>(updateBlog);
                return new SuccessDataResult<ResponseUpdateBlogDto>(updatedBlogDto, ResultMessages.Updated);
            }
        }
    }
}
