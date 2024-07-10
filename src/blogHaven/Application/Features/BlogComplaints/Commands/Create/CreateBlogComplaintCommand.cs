using Application.Constants;
using Application.Features.BlogComplaints.Dtos;
using Application.Features.BlogComplaints.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Commands.Create
{
    public partial class CreateBlogComplaintCommand : IRequest<IDataResult<ResponseCreateBlogComplaintDto>>
    {
        public int BlogId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
        public class CreateBlogComplaintCommandHandler : IRequestHandler<CreateBlogComplaintCommand, IDataResult<ResponseCreateBlogComplaintDto>>
        {
            private readonly IBlogComplaintRepository _blogcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly BlogComplaintBusinessRules _blogcomplaintBusinessRules;
            private readonly IImageService _imageService;

            public CreateBlogComplaintCommandHandler(IBlogComplaintRepository blogcomplaintRepository, IMapper mapper,
                                             BlogComplaintBusinessRules blogcomplaintBusinessRules, IImageService imageService)
            {
                _blogcomplaintRepository = blogcomplaintRepository;
                _mapper = mapper;
                _blogcomplaintBusinessRules = blogcomplaintBusinessRules;
                _imageService = imageService;
            }

            public async Task<IDataResult<ResponseCreateBlogComplaintDto>> Handle(CreateBlogComplaintCommand request, CancellationToken cancellationToken)
            {
                //Todo:  Business rules yazılacak 

                BlogComplaint mappedEntity = _mapper.Map<BlogComplaint>(request);
                BlogComplaint createBlogComplaint = await _blogcomplaintRepository.AddAsync(mappedEntity);
                ResponseCreateBlogComplaintDto createdBlogComplaintDto = _mapper.Map<ResponseCreateBlogComplaintDto>(createBlogComplaint);
                return new SuccessDataResult<ResponseCreateBlogComplaintDto>(createdBlogComplaintDto, ResultMessages.Added);
            }
        }
    }
}
