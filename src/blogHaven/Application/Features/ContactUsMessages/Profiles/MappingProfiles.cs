
using Application.Features.ContactUsMessages.Commands.Create;
using Application.Features.ContactUsMessages.Dtos;
using AutoMapper;
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
        }
    }
}
