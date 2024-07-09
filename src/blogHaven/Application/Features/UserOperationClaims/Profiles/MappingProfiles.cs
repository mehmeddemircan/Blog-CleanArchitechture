using Application.Features.UserOperationClaims.Commands;

using Application.Features.UserOperationClaims.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, ResponseCreateUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        }
    }
}
