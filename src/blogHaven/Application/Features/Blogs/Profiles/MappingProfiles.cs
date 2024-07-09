using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Dtos;
using Application.Features.Blogs.Models;
using Application.Features.Categories.Commands.DeleteCategory;
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

namespace Application.Features.Blogs.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Blog, ResponseCreateBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<IPaginate<Blog>, ResponseBlogListModel>().ReverseMap();
            CreateMap<Blog, ResponseBlogListDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
            CreateMap<Blog, ResponseBlogByIdDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();

            CreateMap<Blog, ResponseDeleteBlogDto>().ReverseMap();
            CreateMap<Blog, DeleteBlogCommand>().ReverseMap();

            CreateMap<Blog, ResponseUpdateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        }
    }
}
