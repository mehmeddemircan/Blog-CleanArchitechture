
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Dtos;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<User>, ResponseUserListModel>()
              .ReverseMap();
            CreateMap<User, ResponseUserListDto>().ReverseMap();
            CreateMap<User, ResponseUserByIdDto>().ReverseMap();

            CreateMap<User, ResponseDeleteUserDto>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
        }
    }
}
