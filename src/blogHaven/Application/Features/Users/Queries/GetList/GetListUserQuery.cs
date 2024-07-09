using Application.Constants;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<IDataResult<ResponseUserListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, IDataResult<ResponseUserListModel>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseUserListModel>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                                                
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                ResponseUserListModel mappedUserListUser = _mapper.Map<ResponseUserListModel>(users);

                return new SuccessDataResult<ResponseUserListModel>(mappedUserListUser, ResultMessages.Listed);
            }
        }
    }
}
