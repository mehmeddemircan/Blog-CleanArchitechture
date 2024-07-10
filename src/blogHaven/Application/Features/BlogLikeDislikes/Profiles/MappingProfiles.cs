using Application.Features.BlogLikeDislikes.Commands.Create;
using Application.Features.BlogLikeDislikes.Commands.Delete;
using Application.Features.BlogLikeDislikes.Commands.Update;
using Application.Features.BlogLikeDislikes.Dtos;
using Application.Features.BlogLikeDislikes.Dtos;
using Application.Features.BlogLikeDislikes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogLikeDislikes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlogLikeDislike, CreateBlogLikeDislikeCommand>().ReverseMap();
            CreateMap<BlogLikeDislike, ResponseCreateBlogLikeDislikeDto>().ReverseMap();

            CreateMap<BlogLikeDislike, UpdateBlogLikeDislikeCommand>().ReverseMap();
            CreateMap<BlogLikeDislike, ResponseUpdateBlogLikeDislikeDto>().ReverseMap();

            CreateMap<BlogLikeDislike, DeleteBlogLikeDislikeCommand>().ReverseMap();
            CreateMap<BlogLikeDislike, ResponseDeleteBlogLikeDislikeDto>().ReverseMap();

            CreateMap<IPaginate<BlogLikeDislike>, ResponseBlogLikeDislikeListModel>().ReverseMap();
            CreateMap<BlogLikeDislike, ResponseBlogLikeDislikeListDto>()
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
         
            .ReverseMap();
            CreateMap<BlogLikeDislike, ResponseBlogLikeDislikeByIdDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
          
            .ReverseMap();
        }
    }
}
