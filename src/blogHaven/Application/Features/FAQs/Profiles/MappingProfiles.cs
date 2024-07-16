using Application.Features.FAQs.Commands.Create;
using Application.Features.FAQs.Commands.Delete;
using Application.Features.FAQs.Commands.Update;
using Application.Features.FAQs.Dtos;
using Application.Features.FAQs.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FAQs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FAQ, ResponseCreateFAQDto>().ReverseMap();
            CreateMap<FAQ, CreateFAQCommand>().ReverseMap();
            CreateMap<IPaginate<FAQ>, ResponseFAQListModel>().ReverseMap();
            CreateMap<FAQ, ResponseFAQListDto>().ReverseMap();
            CreateMap<FAQ, ResponseFAQByIdDto>().ReverseMap();
            CreateMap<FAQ, UpdateFAQCommand>().ReverseMap();
            CreateMap<FAQ, ResponseUpdateFAQDto>().ReverseMap();
            CreateMap<FAQ, ResponseDeleteFAQDto>().ReverseMap();
            CreateMap<FAQ, DeleteFAQCommand>().ReverseMap();
        }
    }
}
