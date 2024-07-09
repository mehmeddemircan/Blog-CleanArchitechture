using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetById
{
    public class GetByIdOperationClaimQuery : IRequest<IDataResult<ResponseOperationClaimByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, IDataResult<ResponseOperationClaimByIdDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper, OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseOperationClaimByIdDto>> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim? operationclaim = await _operationclaimRepository.GetAsync(b => b.Id == request.Id);

                _operationclaimBusinessRules.OperationClaimShouldExistWhenRequested(operationclaim);

                ResponseOperationClaimByIdDto operationclaimGetByIdDto = _mapper.Map<ResponseOperationClaimByIdDto>(operationclaim);
                return new SuccessDataResult<ResponseOperationClaimByIdDto>(operationclaimGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
