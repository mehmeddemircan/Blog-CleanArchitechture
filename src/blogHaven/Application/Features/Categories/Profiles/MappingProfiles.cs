using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Category,ResponseCreateCategoryDto>().ReverseMap(); 
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<IPaginate<Category>, ResponseCategoryListModel>().ReverseMap();
            CreateMap<Category, ResponseCategoryListDto>().ReverseMap();



        }
    }
}
