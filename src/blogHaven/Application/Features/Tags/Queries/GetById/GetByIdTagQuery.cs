using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.Tags.Queries.GetByIdTag
{
    public class GetByIdTagQuery : IRequest<IDataResult<ResponseTagByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQuery, IDataResult<ResponseTagByIdDto>>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;
            private readonly TagBusinessRules _tagBusinessRules;

            public GetByIdTagQueryHandler(ITagRepository tagRepository, IMapper mapper, TagBusinessRules tagBusinessRules)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
                _tagBusinessRules = tagBusinessRules;
            }

            public async Task<IDataResult<ResponseTagByIdDto>> Handle(GetByIdTagQuery request, CancellationToken cancellationToken)
            {
                Tag? tag = await _tagRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Category);

                _tagBusinessRules.TagShouldExistWhenRequested(tag);

                ResponseTagByIdDto tagGetByIdDto = _mapper.Map<ResponseTagByIdDto>(tag);
                return new SuccessDataResult<ResponseTagByIdDto>(tagGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
