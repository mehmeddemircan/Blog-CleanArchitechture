﻿using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
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
            CreateMap<Category,ResponseCategoryByIdDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category,ResponseUpdateCategoryDto>().ReverseMap();
            CreateMap<Category,ResponseDeleteCategoryDto>().ReverseMap();
            CreateMap<Category,DeleteCategoryCommand>().ReverseMap();






        }
    }
}
