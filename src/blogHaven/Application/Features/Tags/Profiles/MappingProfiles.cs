
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Tags.Commands.CreateTag;
using Application.Features.Tags.Dtos;
using Application.Features.Tags.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tag, ResponseCreateTagDto>().ReverseMap();
            CreateMap<Tag, CreateTagCommand>().ReverseMap();
            CreateMap<IPaginate<Tag>, ResponseTagListModel>()
                .ReverseMap();
            CreateMap<Tag, ResponseTagListDto>().ReverseMap();


            CreateMap<Tag, ResponseTagByIdDto>()
                 .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.Name))
                .ReverseMap();
        }
    }
}
