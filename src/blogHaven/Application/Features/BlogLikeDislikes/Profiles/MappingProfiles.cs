using Application.Features.BlogLikeDislikes.Commands.Create;
using Application.Features.BlogLikeDislikes.Dtos;
using AutoMapper;
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
        }
    }
}
