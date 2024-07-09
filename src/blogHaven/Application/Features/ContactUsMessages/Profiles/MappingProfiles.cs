
using Application.Features.ContactUsMessages.Dtos;
using Application.Features.ContactUsMessages.Models;
using Application.Features.ContactUsMessages.Commands.Create;
using Application.Features.ContactUsMessages.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContactUsMessages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContactUsMessage, ResponseCreateContactUsMessageDto>().ReverseMap();
            CreateMap<ContactUsMessage, CreateContactUsMessageCommand>().ReverseMap();

            CreateMap<IPaginate<ContactUsMessage>, ResponseContactUsMessageListModel>().ReverseMap();
            CreateMap<ContactUsMessage, ResponseContactUsMessageListDto>()
            .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            
            .ReverseMap();
            CreateMap<ContactUsMessage, ResponseContactUsMessageByIdDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            
            .ReverseMap();
        }
    }
}
