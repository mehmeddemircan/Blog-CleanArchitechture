using Application.Constants;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<IDataResult<ResponseUserByIdDto>>
    {
        public int Id { get; set; }
        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, IDataResult<ResponseUserByIdDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper,UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseUserByIdDto>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(b => b.Id == request.Id);

                _userBusinessRules.UserShouldExistWhenRequested(user);

                ResponseUserByIdDto mappedUserByIdUser = _mapper.Map<ResponseUserByIdDto>(user);

                return new SuccessDataResult<ResponseUserByIdDto>(mappedUserByIdUser, ResultMessages.Listed);
            }
        }
    }
}
