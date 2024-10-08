﻿using Application.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
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

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public partial class UpdateUserOperationClaimCommand : IRequest<IDataResult<ResponseUpdateUserOperationClaimDto>>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, IDataResult<ResponseUpdateUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateUserOperationClaimDto>> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _useroperationclaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(request.OperationClaimId,request.UserId);


                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow; 
                UserOperationClaim updateUserOperationClaim = await _useroperationclaimRepository.UpdateAsync(mappedEntity);
                ResponseUpdateUserOperationClaimDto updatedUserOperationClaimDto = _mapper.Map<ResponseUpdateUserOperationClaimDto>(updateUserOperationClaim);
                return new SuccessDataResult<ResponseUpdateUserOperationClaimDto>(updatedUserOperationClaimDto, ResultMessages.Updated);
            }
        }
    }
}
