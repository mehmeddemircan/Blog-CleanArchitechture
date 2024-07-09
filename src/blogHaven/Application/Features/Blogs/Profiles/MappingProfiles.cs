
using Application.Features.Blogs.Commands;
using Application.Features.Blogs.Dtos;
using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Blog, ResponseCreateBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        }
    }
}
