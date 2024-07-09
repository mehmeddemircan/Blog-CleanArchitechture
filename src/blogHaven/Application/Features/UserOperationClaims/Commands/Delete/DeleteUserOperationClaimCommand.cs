using Application.Constants;
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

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public partial class DeleteUserOperationClaimCommand : IRequest<IDataResult<ResponseDeleteUserOperationClaimDto>>
    {
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IDataResult<ResponseDeleteUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteUserOperationClaimDto>> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deleteUserOperationClaim = await _useroperationclaimRepository.DeleteAsync(mappedEntity);
                ResponseDeleteUserOperationClaimDto deletedUserOperationClaimDto = _mapper.Map<ResponseDeleteUserOperationClaimDto>(deleteUserOperationClaim);
                return new SuccessDataResult<ResponseDeleteUserOperationClaimDto>(deletedUserOperationClaimDto, ResultMessages.Deleted);

            }


        }
    }
}
