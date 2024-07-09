
using Application.Features.Comments.Dtos;
using Application.Features.Comments.Models;
using Application.Features.Categories.Dtos;
using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, ResponseCreateCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();

            CreateMap<IPaginate<Comment>, ResponseCommentListModel>().ReverseMap();
            CreateMap<Comment, ResponseCommentListDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
            .ReverseMap();
            CreateMap<Comment, ResponseCommentByIdDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title))
            .ReverseMap();
        }
    }
}
