using Application.Features.Testimonials.Commands.Delete;
using Application.Features.Testimonials.Commands.Update;
using Application.Features.Testimonials.Dtos;
using Application.Features.Testimonials.Models;
using Application.Features.Testimonials.Commands.Create;

using Application.Features.Testimonials.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Testimonials.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Testimonial, ResponseCreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<IPaginate<Testimonial>, ResponseTestimonialListModel>().ReverseMap();
            CreateMap<Testimonial, ResponseTestimonialListDto>().ReverseMap();
            CreateMap<Testimonial, ResponseTestimonialByIdDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, ResponseUpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResponseDeleteTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, DeleteTestimonialCommand>().ReverseMap();
        }
    }
}
