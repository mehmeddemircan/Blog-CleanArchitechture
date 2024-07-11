using Application.Features.BlogFavorites.Commands.Create;
using Application.Features.BlogFavorites.Commands.Delete;
using Application.Features.BlogFavorites.Commands.Update;
using Application.Features.BlogFavorites.Dtos;
using Application.Features.BlogFavorites.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogFavorites.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlogFavorite, CreateBlogFavoriteCommand>().ReverseMap();
            CreateMap<BlogFavorite, ResponseCreateBlogFavoriteDto>().ReverseMap();

            CreateMap<BlogFavorite, UpdateBlogFavoriteCommand>().ReverseMap();
            CreateMap<BlogFavorite, ResponseUpdateBlogFavoriteDto>().ReverseMap();

            CreateMap<BlogFavorite, DeleteBlogFavoriteCommand>().ReverseMap();
            CreateMap<BlogFavorite, ResponseDeleteBlogFavoriteDto>().ReverseMap();

            CreateMap<IPaginate<BlogFavorite>, ResponseBlogFavoriteListModel>().ReverseMap();
            CreateMap<BlogFavorite, ResponseBlogFavoriteListDto>()
                .ForMember(dest => dest.AuthorFirstName, opt => opt.MapFrom(src => src.Blog.User.FirstName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(src => src.Blog.User.LastName))
                .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
                .ForMember(dest => dest.BlogDescription, opt => opt.MapFrom(src => src.Blog.Description))
                .ForMember(dest => dest.BlogThumbNailImage, opt => opt.MapFrom(src => src.Blog.ThumbNailImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Blog.Category.Name))
                .ReverseMap();



            CreateMap<BlogFavorite, ResponseBlogFavoriteByIdDto>()
                    .ForMember(dest => dest.AuthorFirstName, opt => opt.MapFrom(src => src.Blog.User.FirstName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(src => src.Blog.User.LastName))
                .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
                .ForMember(dest => dest.BlogDescription, opt => opt.MapFrom(src => src.Blog.Description))
                .ForMember(dest => dest.BlogThumbNailImage, opt => opt.MapFrom(src => src.Blog.ThumbNailImage))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Blog.Category.Name))

            .ReverseMap();
        }
    }
}
