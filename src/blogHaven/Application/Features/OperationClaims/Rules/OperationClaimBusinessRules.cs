
using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationclaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationclaimRepository)
        {
            _operationclaimRepository = operationclaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationclaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.OperationClaimNameExists);
            }
        }
        public void OperationClaimShouldExistWhenRequested(OperationClaim operationclaim)
        {
            if (operationclaim == null)
            {
                throw new BusinessException(ExceptionMessages.OperationClaimShouldExistWhenRequested);
            }
        }
    }
}
