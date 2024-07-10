using Application.Features.CommentLikeDislikes.Commands.Create;
using Application.Features.CommentLikeDislikes.Commands.Delete;
using Application.Features.CommentLikeDislikes.Commands.Update;
using Application.Features.CommentLikeDislikes.Dtos;
using Application.Features.CommentLikeDislikes.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentLikeDislikes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CommentLikeDislike, CreateCommentLikeDislikeCommand>().ReverseMap();
            CreateMap<CommentLikeDislike, ResponseCreateCommentLikeDislikeDto>().ReverseMap();

            CreateMap<CommentLikeDislike, UpdateCommentLikeDislikeCommand>().ReverseMap();
            CreateMap<CommentLikeDislike, ResponseUpdateCommentLikeDislikeDto>().ReverseMap();

            CreateMap<CommentLikeDislike, DeleteCommentLikeDislikeCommand>().ReverseMap();
            CreateMap<CommentLikeDislike, ResponseDeleteCommentLikeDislikeDto>().ReverseMap();

            CreateMap<IPaginate<CommentLikeDislike>, ResponseCommentLikeDislikeListModel>().ReverseMap();
            CreateMap<CommentLikeDislike, ResponseCommentLikeDislikeListDto>()
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))

            .ReverseMap();
            CreateMap<CommentLikeDislike, ResponseCommentLikeDislikeByIdDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))

            .ReverseMap();
        }
    }
}
