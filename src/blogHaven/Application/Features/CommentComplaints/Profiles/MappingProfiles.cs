using Application.Features.CommentComplaints.Commands.Create;
using Application.Features.CommentComplaints.Dtos;
using AutoMapper;
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

        }
    }
}
