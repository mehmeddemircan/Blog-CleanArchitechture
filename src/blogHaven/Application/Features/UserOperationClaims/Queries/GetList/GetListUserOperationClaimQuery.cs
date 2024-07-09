using Application.Constants;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery : IRequest<IDataResult<ResponseUserOperationClaimListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, IDataResult<ResponseUserOperationClaimListModel>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseUserOperationClaimListModel>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> useroperationclaims = await _useroperationclaimRepository.GetListAsync(include: source => 
                                                 source.Include(uoc => uoc.User)
                                                .Include(uoc => uoc.OperationClaim),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                ResponseUserOperationClaimListModel mappedUserOperationClaimListUserOperationClaim = _mapper.Map<ResponseUserOperationClaimListModel>(useroperationclaims);

                return new SuccessDataResult<ResponseUserOperationClaimListModel>(mappedUserOperationClaimListUserOperationClaim,ResultMessages.Listed);
            }
        }
    }
}
