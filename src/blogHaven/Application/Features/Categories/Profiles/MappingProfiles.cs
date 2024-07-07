using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using AutoMapper;
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
            CreateMap<Category,CreateCategoryDto>().ReverseMap(); 
            CreateMap<Category,CreateCategoryCommand>().ReverseMap(); 
           
        }
    }
}
