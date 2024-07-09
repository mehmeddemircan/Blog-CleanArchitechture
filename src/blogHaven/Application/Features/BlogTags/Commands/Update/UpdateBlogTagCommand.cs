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

namespace Application.Features.BlogTags.Commands.Update
{
    public partial class UpdateBlogTagCommand : IRequest<IDataResult<ResponseUpdateBlogTagDto>>
    {
        public int Id { get; set; }

        public int TagId { get; set; }

        public int BlogId { get; set; }

        public class UpdateBlogTagCommandHandler : IRequestHandler<UpdateBlogTagCommand, IDataResult<ResponseUpdateBlogTagDto>>
        {
            private readonly IBlogTagRepository _blogtagRepository;
            private readonly IMapper _mapper;
            private readonly BlogTagBusinessRules _blogtagBusinessRules;

            public UpdateBlogTagCommandHandler(IBlogTagRepository blogtagRepository, IMapper mapper,
                                             BlogTagBusinessRules blogtagBusinessRules)
            {
                _blogtagRepository = blogtagRepository;
                _mapper = mapper;
                _blogtagBusinessRules = blogtagBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateBlogTagDto>> Handle(UpdateBlogTagCommand request, CancellationToken cancellationToken)
            {
                //await _blogtagBusinessRules.BlogTagNameCanNotBeDuplicatedWhenInserted(request.Name);


                BlogTag mappedEntity = _mapper.Map<BlogTag>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                BlogTag updateBlogTag = await _blogtagRepository.UpdateAsync(mappedEntity);
                ResponseUpdateBlogTagDto updatedBlogTagDto = _mapper.Map<ResponseUpdateBlogTagDto>(updateBlogTag);
                return new SuccessDataResult<ResponseUpdateBlogTagDto>(updatedBlogTagDto, ResultMessages.Updated);
            }
        }
    }
}
