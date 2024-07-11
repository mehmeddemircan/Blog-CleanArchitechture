using Application.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.Create
{
    public partial class CreateUserOperationClaimCommand : IRequest<IDataResult<ResponseCreateUserOperationClaimDto>>
    {

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }



        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, IDataResult<ResponseCreateUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateUserOperationClaimDto>> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _useroperationclaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(request.OperationClaimId,request.UserId);


                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createUserOperationClaim = await _useroperationclaimRepository.AddAsync(mappedEntity);
                ResponseCreateUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<ResponseCreateUserOperationClaimDto>(createUserOperationClaim);
                return new SuccessDataResult<ResponseCreateUserOperationClaimDto>(createdUserOperationClaimDto, ResultMessages.Added);
            }
        }
    }
}
