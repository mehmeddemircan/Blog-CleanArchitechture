
using Application.Features.Tags.Models;

using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Queries.GetListTag
{
    public class GetListTagQuery : IRequest<ResponseTagListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, ResponseTagListModel>
        {
            private readonly ITagRepository _tagRepository;
            private readonly IMapper _mapper;

            public GetListTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
            {
                _tagRepository = tagRepository;
                _mapper = mapper;
            }

            public async Task<ResponseTagListModel> Handle(GetListTagQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Tag> tags = await _tagRepository.GetListAsync(include:
                                                m => m.Include(c => c.Category),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                ResponseTagListModel mappedTagListTag = _mapper.Map<ResponseTagListModel>(tags);

                return mappedTagListTag;
            }
        }
    }
}
