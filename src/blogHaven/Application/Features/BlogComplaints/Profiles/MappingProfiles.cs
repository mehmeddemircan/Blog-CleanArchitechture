using Application.Features.BlogComplaints.Commands.Create;
using Application.Features.BlogComplaints.Commands.Delete;
using Application.Features.BlogComplaints.Commands.Update;
using Application.Features.BlogComplaints.Dtos;
using Application.Features.BlogComplaints.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlogComplaint, CreateBlogComplaintCommand>().ReverseMap();
            CreateMap<BlogComplaint, ResponseCreateBlogComplaintDto>().ReverseMap();


            CreateMap<BlogComplaint, ResponseDeleteBlogComplaintDto>().ReverseMap();
            CreateMap<BlogComplaint, DeleteBlogComplaintCommand>().ReverseMap();

            CreateMap<BlogComplaint, ResponseUpdateBlogComplaintDto>().ReverseMap();
            CreateMap<BlogComplaint, UpdateBlogComplaintCommand>().ReverseMap();

            CreateMap<IPaginate<BlogComplaint>, ResponseBlogComplaintListModel>().ReverseMap();
            CreateMap<BlogComplaint, ResponseBlogComplaintListDto>()
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.Complainer.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.Complainer.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Complainer.Email))

            .ReverseMap();
            CreateMap<BlogComplaint, ResponseBlogComplaintByIdDto>()
               .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.Complainer.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.Complainer.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Complainer.Email))

            .ReverseMap();
        }
    }
}
