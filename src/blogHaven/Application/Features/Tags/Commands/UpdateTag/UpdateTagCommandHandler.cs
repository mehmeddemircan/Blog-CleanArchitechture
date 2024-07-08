using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Features.Tags.Dtos;
using Application.Features.Tags.Rules;
using Application.ResultMessages;
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

namespace Application.Features.Tags.Commands.UpdateTag
{
    public partial class UpdateTagCommand
    {
        public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, IDataResult<ResponseUpdateTagDto>>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public UpdateTagCommandHandler(ITagRepository tagRepository, IMapper mapper,
                                             TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateTagDto>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
            {
                await _tagBusinessRules.TagNameCanNotBeDuplicatedWhenInserted(request.Name);


                Tag mappedEntity = _mapper.Map<Tag>(request);
                Tag updateTag = await _tagRepository.UpdateAsync(mappedEntity);
                ResponseUpdateTagDto updatedTagDto = _mapper.Map<ResponseUpdateTagDto>(updateTag);
                return new SuccessDataResult<ResponseUpdateTagDto>(updatedTagDto, Messages.Updated);
            }
        }
    }
}
