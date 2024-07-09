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

namespace Application.Features.Blogs.Commands.Delete
{
    public partial class DeleteBlogCommand : IRequest<IDataResult<ResponseDeleteBlogDto>>
    {
        public int Id { get; set; }

        public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, IDataResult<ResponseDeleteBlogDto>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            private readonly BlogBusinessRules _blogBusinessRules;

            public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper,
                                             BlogBusinessRules blogBusinessRules)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
                _blogBusinessRules = blogBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteBlogDto>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
            {
                Blog mappedEntity = _mapper.Map<Blog>(request);
                Blog deleteBlog = await _blogRepository.DeleteAsync(mappedEntity);
                ResponseDeleteBlogDto deletedBlogDto = _mapper.Map<ResponseDeleteBlogDto>(deleteBlog);
                return new SuccessDataResult<ResponseDeleteBlogDto>(deletedBlogDto, ResultMessages.Deleted);

            }


        }

    }

}
