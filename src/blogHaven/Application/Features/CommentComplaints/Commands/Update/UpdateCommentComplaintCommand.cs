using Application.Constants;
using Application.Features.CommentComplaints.Dtos;
using Application.Features.CommentComplaints.Rules;
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

namespace Application.Features.CommentComplaints.Commands.Update
{
    public partial class UpdateCommentComplaintCommand : IRequest<IDataResult<ResponseUpdateCommentComplaintDto>>
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
        public class UpdateCommentComplaintCommandHandler : IRequestHandler<UpdateCommentComplaintCommand, IDataResult<ResponseUpdateCommentComplaintDto>>
        {
            private readonly ICommentComplaintRepository _commentcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly CommentComplaintBusinessRules _commentcomplaintBusinessRules;

            public UpdateCommentComplaintCommandHandler(ICommentComplaintRepository commentcomplaintRepository, IMapper mapper,
                                             CommentComplaintBusinessRules commentcomplaintBusinessRules)
            {
                _commentcomplaintRepository = commentcomplaintRepository;
                _mapper = mapper;
                _commentcomplaintBusinessRules = commentcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateCommentComplaintDto>> Handle(UpdateCommentComplaintCommand request, CancellationToken cancellationToken)
            {



                CommentComplaint mappedEntity = _mapper.Map<CommentComplaint>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                CommentComplaint updateCommentComplaint = await _commentcomplaintRepository.UpdateAsync(mappedEntity);
                ResponseUpdateCommentComplaintDto updatedCommentComplaintDto = _mapper.Map<ResponseUpdateCommentComplaintDto>(updateCommentComplaint);
                return new SuccessDataResult<ResponseUpdateCommentComplaintDto>(updatedCommentComplaintDto, ResultMessages.Updated);
            }
        }
    }
}
