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

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public partial class CreateOperationClaimCommand : IRequest<IDataResult<ResponseCreateOperationClaimDto>>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, IDataResult<ResponseCreateOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateOperationClaimDto>> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationclaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);


                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                OperationClaim createOperationClaim = await _operationclaimRepository.AddAsync(mappedEntity);
                ResponseCreateOperationClaimDto createdOperationClaimDto = _mapper.Map<ResponseCreateOperationClaimDto>(createOperationClaim);
                return new SuccessDataResult<ResponseCreateOperationClaimDto>(createdOperationClaimDto, ResultMessages.Added);
            }
        }
    }
}
