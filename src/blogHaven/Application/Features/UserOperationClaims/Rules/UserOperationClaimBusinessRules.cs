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

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _useroperationclaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository useroperationclaimRepository)
        {
            _useroperationclaimRepository = useroperationclaimRepository;
        }

        public async Task UserOperationClaimCanNotBeDuplicatedWhenInserted(int operationClaimId)
        {
            IPaginate<UserOperationClaim> result = await _useroperationclaimRepository.GetListAsync(b => b.OperationClaimId == operationClaimId);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.UserOperationClaimNameExists);
            }
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim useroperationclaim)
        {
            if (useroperationclaim == null)
            {
                throw new BusinessException(ExceptionMessages.UserOperationClaimShouldExistWhenRequested);
            }
        }
    }
}
