using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedInResponse>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public LoginCommand()
        {
            UserForLoginDto = null!;
            IpAddress = string.Empty;
        }

        public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress)
        {
            UserForLoginDto = userForLoginDto;
            IpAddress = ipAddress;
        }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInResponse>
        {
            private readonly AuthBusinessRules _authBusinessRules;
           
            private readonly IAuthService _authService;
            private readonly IUserService _userService;

            public LoginCommandHandler(
                IUserService userService,
                IAuthService authService,
                AuthBusinessRules authBusinessRules
             
            )
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
              
            }

            public async Task<LoggedInResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetAsync(
                    predicate: u => u.Email == request.UserForLoginDto.Email
                );
                await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
                await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);

                LoggedInResponse loggedResponse = new();

              
                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
               

                loggedResponse.AccessToken = createdAccessToken;
                loggedResponse.RefreshToken = addedRefreshToken;
                return loggedResponse;
            }
        }
    }
}
