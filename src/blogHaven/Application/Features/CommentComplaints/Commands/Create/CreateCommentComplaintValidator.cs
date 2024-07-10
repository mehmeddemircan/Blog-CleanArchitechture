using Application.Constants;
using Application.Features.CommentComplaints.Dtos;
using Application.Features.CommentComplaints.Rules;
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

namespace Application.Features.CommentComplaints.Commands.Create
{
    public partial class CreateCommentComplaintCommand : IRequest<IDataResult<ResponseCreateCommentComplaintDto>>
    {
        public int CommentId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
        public class CreateCommentComplaintCommandHandler : IRequestHandler<CreateCommentComplaintCommand, IDataResult<ResponseCreateCommentComplaintDto>>
        {
            private readonly ICommentComplaintRepository _commentcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly CommentComplaintBusinessRules _commentcomplaintBusinessRules;
            private readonly IImageService _imageService;

            public CreateCommentComplaintCommandHandler(ICommentComplaintRepository commentcomplaintRepository, IMapper mapper,
                                             CommentComplaintBusinessRules commentcomplaintBusinessRules, IImageService imageService)
            {
                _commentcomplaintRepository = commentcomplaintRepository;
                _mapper = mapper;
                _commentcomplaintBusinessRules = commentcomplaintBusinessRules;
                _imageService = imageService;
            }

            public async Task<IDataResult<ResponseCreateCommentComplaintDto>> Handle(CreateCommentComplaintCommand request, CancellationToken cancellationToken)
            {
                   //Todo:  Business rules yazılacak 

                CommentComplaint mappedEntity = _mapper.Map<CommentComplaint>(request);
                CommentComplaint createCommentComplaint = await _commentcomplaintRepository.AddAsync(mappedEntity);
                ResponseCreateCommentComplaintDto createdCommentComplaintDto = _mapper.Map<ResponseCreateCommentComplaintDto>(createCommentComplaint);
                return new SuccessDataResult<ResponseCreateCommentComplaintDto>(createdCommentComplaintDto, ResultMessages.Added);
            }
        }
    }
}
