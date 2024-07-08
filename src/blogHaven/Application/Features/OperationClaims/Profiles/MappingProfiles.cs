
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<OperationClaim, ResponseCreateOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, ResponseOperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, ResponseOperationClaimListDto>().ReverseMap();
            CreateMap<OperationClaim, ResponseOperationClaimByIdDto>().ReverseMap();
        }
    }
}
