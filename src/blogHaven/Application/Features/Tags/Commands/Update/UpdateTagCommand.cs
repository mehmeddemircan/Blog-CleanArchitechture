﻿using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Tags.Dtos;
using Application.Features.Tags.Rules;
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
    public partial class UpdateTagCommand : IRequest<IDataResult<ResponseUpdateTagDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

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
                mappedEntity.UpdatedTime = DateTime.UtcNow; 
                Tag updateTag = await _tagRepository.UpdateAsync(mappedEntity);
                ResponseUpdateTagDto updatedTagDto = _mapper.Map<ResponseUpdateTagDto>(updateTag);
                return new SuccessDataResult<ResponseUpdateTagDto>(updatedTagDto, ResultMessages.Updated);
            }
        }
    }
}
