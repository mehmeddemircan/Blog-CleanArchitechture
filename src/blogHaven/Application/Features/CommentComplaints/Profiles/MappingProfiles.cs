using Application.Features.CommentComplaints.Dtos;
using Application.Features.CommentComplaints.Models;
using Application.Features.CommentComplaints.Commands.Create;
using Application.Features.CommentComplaints.Commands.Delete;
using Application.Features.CommentComplaints.Commands.Update;
using Application.Features.CommentComplaints.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentComplaints.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CommentComplaint, CreateCommentComplaintCommand>().ReverseMap();
            CreateMap<CommentComplaint, ResponseCreateCommentComplaintDto>().ReverseMap();


            CreateMap<CommentComplaint, ResponseDeleteCommentComplaintDto>().ReverseMap();
            CreateMap<CommentComplaint, DeleteCommentComplaintCommand>().ReverseMap();

            CreateMap<CommentComplaint, ResponseUpdateCommentComplaintDto>().ReverseMap();
            CreateMap<CommentComplaint, UpdateCommentComplaintCommand>().ReverseMap();

            CreateMap<IPaginate<CommentComplaint>, ResponseCommentComplaintListModel>().ReverseMap();
            CreateMap<CommentComplaint, ResponseCommentComplaintListDto>()
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.Complainer.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.Complainer.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Complainer.Email))
           
            .ReverseMap();
            CreateMap<CommentComplaint, ResponseCommentComplaintByIdDto>()
               .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.Complainer.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.Complainer.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Complainer.Email))

            .ReverseMap();
        }
    }
}
