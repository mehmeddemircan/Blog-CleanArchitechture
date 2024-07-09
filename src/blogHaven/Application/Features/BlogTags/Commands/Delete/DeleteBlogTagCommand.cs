using Application.Constants;
using Application.Features.BlogTags.Dtos;
using Application.Features.BlogTags.Rules;
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

namespace Application.Features.BlogTags.Commands.Delete
{
    public partial class DeleteBlogTagCommand : IRequest<IDataResult<ResponseDeleteBlogTagDto>>
    {
        public int Id { get; set; }

        public class DeleteBlogTagCommandHandler : IRequestHandler<DeleteBlogTagCommand, IDataResult<ResponseDeleteBlogTagDto>>
        {
            private readonly IBlogTagRepository _blogtagRepository;
            private readonly IMapper _mapper;
            private readonly BlogTagBusinessRules _blogtagBusinessRules;

            public DeleteBlogTagCommandHandler(IBlogTagRepository blogtagRepository, IMapper mapper,
                                             BlogTagBusinessRules blogtagBusinessRules)
            {
                _blogtagRepository = blogtagRepository;
                _mapper = mapper;
                _blogtagBusinessRules = blogtagBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteBlogTagDto>> Handle(DeleteBlogTagCommand request, CancellationToken cancellationToken)
            {
                BlogTag mappedEntity = _mapper.Map<BlogTag>(request);
                BlogTag deleteBlogTag = await _blogtagRepository.DeleteAsync(mappedEntity);
                ResponseDeleteBlogTagDto deletedBlogTagDto = _mapper.Map<ResponseDeleteBlogTagDto>(deleteBlogTag);
                return new SuccessDataResult<ResponseDeleteBlogTagDto>(deletedBlogTagDto, ResultMessages.Deleted);

            }


        }

    }
}
