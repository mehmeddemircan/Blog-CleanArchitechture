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

namespace Application.Features.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery : IRequest<IDataResult<ResponseUserOperationClaimByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, IDataResult<ResponseUserOperationClaimByIdDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper, UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<ResponseUserOperationClaimByIdDto>> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim? useroperationclaim = await _useroperationclaimRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.User,
        b => b.OperationClaim);

                _useroperationclaimBusinessRules.UserOperationClaimShouldExistWhenRequested(useroperationclaim);

                ResponseUserOperationClaimByIdDto useroperationclaimGetByIdDto = _mapper.Map<ResponseUserOperationClaimByIdDto>(useroperationclaim);
                return new SuccessDataResult<ResponseUserOperationClaimByIdDto>(useroperationclaimGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
