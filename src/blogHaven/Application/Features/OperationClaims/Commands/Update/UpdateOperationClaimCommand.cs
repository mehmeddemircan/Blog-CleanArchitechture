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

namespace Application.Features.OperationClaims.Commands.Update
{
    public partial class UpdateOperationClaimCommand : IRequest<IDataResult<ResponseUpdateOperationClaimDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, IDataResult<ResponseUpdateOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateOperationClaimDto>> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationclaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);


                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                OperationClaim updateOperationClaim = await _operationclaimRepository.UpdateAsync(mappedEntity);
                ResponseUpdateOperationClaimDto updatedOperationClaimDto = _mapper.Map<ResponseUpdateOperationClaimDto>(updateOperationClaim);
                return new SuccessDataResult<ResponseUpdateOperationClaimDto>(updatedOperationClaimDto, ResultMessages.Updated);
            }
        }
    }
}
