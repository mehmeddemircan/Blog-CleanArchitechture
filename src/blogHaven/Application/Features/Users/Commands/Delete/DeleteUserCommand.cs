using Application.Constants;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
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

namespace Application.Features.Users.Commands.Delete
{
    public partial class DeleteUserCommand : IRequest<IDataResult<ResponseDeleteUserDto>>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IDataResult<ResponseDeleteUserDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper,
                                             UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User mappedEntity = _mapper.Map<User>(request);
                User deleteUser = await _userRepository.DeleteAsync(mappedEntity);
                ResponseDeleteUserDto deletedUserDto = _mapper.Map<ResponseDeleteUserDto>(deleteUser);
                return new SuccessDataResult<ResponseDeleteUserDto>(deletedUserDto, ResultMessages.Deleted);

            }


        }
    }
}
