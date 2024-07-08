using Application.Constants;
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

namespace Application.Features.Tags.Commands.CreateTag
{
    public partial class CreateTagCommand : IRequest<IDataResult<ResponseCreateTagDto>>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, IDataResult<ResponseCreateTagDto>>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper,
                                             TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateTagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
            {
                await _tagBusinessRules.TagNameCanNotBeDuplicatedWhenInserted(request.Name);


                Tag mappedEntity = _mapper.Map<Tag>(request);
                Tag createTag = await _tagRepository.AddAsync(mappedEntity);
                ResponseCreateTagDto createdTagDto = _mapper.Map<ResponseCreateTagDto>(createTag);
                return new SuccessDataResult<ResponseCreateTagDto>(createdTagDto, ResultMessages.Added);
            }
        }
    }
}
