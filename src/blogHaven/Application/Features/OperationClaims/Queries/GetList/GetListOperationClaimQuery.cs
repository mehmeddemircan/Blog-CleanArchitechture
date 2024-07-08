﻿using Application.Features.Categories.Models;
using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<ResponseOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, ResponseOperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
            }

            public async Task<ResponseOperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> categories = await _operationclaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ResponseOperationClaimListModel mappedOperationClaimListModel = _mapper.Map<ResponseOperationClaimListModel>(categories);

                return mappedOperationClaimListModel;
            }
        }
    }
}
