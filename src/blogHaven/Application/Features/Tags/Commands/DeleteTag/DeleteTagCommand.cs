using Application.Features.Categories.Dtos;
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

namespace Application.Features.Tags.Commands.DeleteTag
{
    public partial class DeleteTagCommand : IRequest<IDataResult<ResponseDeleteTagDto>>
    {
        public int Id { get; set; }

        public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, IDataResult<ResponseDeleteTagDto>>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public DeleteTagCommandHandler(ITagRepository tagRepository, IMapper mapper,
                                             TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteTagDto>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
            {
                Tag mappedEntity = _mapper.Map<Tag>(request);
                Tag deleteTag = await _tagRepository.DeleteAsync(mappedEntity);
                ResponseDeleteTagDto deletedTagDto = _mapper.Map<ResponseDeleteTagDto>(deleteTag);
                return new SuccessDataResult<ResponseDeleteTagDto>(deletedTagDto, Messages.Deleted);

            }


        }
    }
}
