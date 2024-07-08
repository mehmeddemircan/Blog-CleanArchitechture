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

namespace Application.Features.OperationClaims.Commands.Delete
{
    public partial class DeleteOperationClaimCommand : IRequest<IDataResult<ResponseDeleteOperationClaimDto>>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, IDataResult<ResponseDeleteOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteOperationClaimDto>> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                OperationClaim deleteOperationClaim = await _operationclaimRepository.DeleteAsync(mappedEntity);
                ResponseDeleteOperationClaimDto deletedOperationClaimDto = _mapper.Map<ResponseDeleteOperationClaimDto>(deleteOperationClaim);
                return new SuccessDataResult<ResponseDeleteOperationClaimDto>(deletedOperationClaimDto, ResultMessages.Deleted);

            }


        }

    }

}
