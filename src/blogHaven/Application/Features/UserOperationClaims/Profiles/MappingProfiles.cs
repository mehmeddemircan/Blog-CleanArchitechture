using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
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
            CreateMap<IPaginate<UserOperationClaim>, ResponseUserOperationClaimListModel>()
                .ReverseMap();
            CreateMap<UserOperationClaim, ResponseUserOperationClaimListDto>()
                 .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                 .ForMember(dest => dest.OperationClaimName, opt => opt.MapFrom(src => src.OperationClaim.Name))
                .ReverseMap();

            CreateMap<UserOperationClaim, ResponseUserOperationClaimByIdDto>()
             .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
             .ForMember(dest => dest.OperationClaimName, opt => opt.MapFrom(src => src.OperationClaim.Name))
            .ReverseMap();
        }
    }
}
