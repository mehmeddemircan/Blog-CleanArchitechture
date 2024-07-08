using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
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

namespace Application.Features.Auths.Dtos
{
    public class LoggedInResponse : IDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
   

        public LoggedHttpResponse ToHttpResponse()
        {
            return new() { AccessToken = AccessToken };
        }

        public class LoggedHttpResponse
        {
            public AccessToken? AccessToken { get; set; }
            
        }
    }
}
