
using Application.Features.Blogs.Dtos;
using Application.Features.BlogTags.Commands.Create;
using Application.Features.BlogTags.Commands.Delete;
using Application.Features.BlogTags.Commands.Update;
using Application.Features.BlogTags.Dtos;
using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogTags.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlogTag, ResponseCreateBlogTagDto>().ReverseMap();
            CreateMap<BlogTag, CreateBlogTagCommand>().ReverseMap();

            CreateMap<BlogTag, ResponseBlogTagListDto>()
                .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name))
                .ReverseMap();

            CreateMap<BlogTag, ResponseDeleteBlogTagDto>().ReverseMap();
            CreateMap<BlogTag, DeleteBlogTagCommand>().ReverseMap();

            CreateMap<BlogTag, ResponseUpdateBlogTagDto>().ReverseMap();
            CreateMap<BlogTag, UpdateBlogTagCommand>().ReverseMap();
        }
    }
}
