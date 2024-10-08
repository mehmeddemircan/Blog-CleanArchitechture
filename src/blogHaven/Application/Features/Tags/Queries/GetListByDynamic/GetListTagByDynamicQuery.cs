﻿using Application.Constants;
using Application.Features.Tags.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Queries.GetListTagByCategory
{
    public class GetListTagByDynamicQuery : IRequest<IDataResult<ResponseTagListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTagByDynamicQueryHandler : IRequestHandler<GetListTagByDynamicQuery, IDataResult<ResponseTagListModel>>
        {

            private readonly IMapper _mapper;
            private readonly ITagRepository _tagRepository;

            public GetListTagByDynamicQueryHandler(IMapper mapper, ITagRepository tagRepository)
            {
                _mapper = mapper;
                _tagRepository = tagRepository;
            }

            public async Task<IDataResult<ResponseTagListModel>> Handle(GetListTagByDynamicQuery request, CancellationToken cancellationToken)
            {
              
                IPaginate<Tag> tags = await _tagRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              m => m.Include(c => c.Category),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
               
                ResponseTagListModel mappedTags = _mapper.Map<ResponseTagListModel>(tags);
                return new SuccessDataResult<ResponseTagListModel>(mappedTags,ResultMessages.Listed);
            }
        }
    }
}
