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

namespace Application.Features.CommentComplaints.Commands.Delete
{
    public partial class DeleteCommentComplaintCommand : IRequest<IDataResult<ResponseDeleteCommentComplaintDto>>
    {
        public int Id { get; set; }

        public class DeleteCommentComplaintCommandHandler : IRequestHandler<DeleteCommentComplaintCommand, IDataResult<ResponseDeleteCommentComplaintDto>>
        {
            private readonly ICommentComplaintRepository _commentcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly CommentComplaintBusinessRules _commentcomplaintBusinessRules;

            public DeleteCommentComplaintCommandHandler(ICommentComplaintRepository commentcomplaintRepository, IMapper mapper,
                                             CommentComplaintBusinessRules commentcomplaintBusinessRules)
            {
                _commentcomplaintRepository = commentcomplaintRepository;
                _mapper = mapper;
                _commentcomplaintBusinessRules = commentcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteCommentComplaintDto>> Handle(DeleteCommentComplaintCommand request, CancellationToken cancellationToken)
            {
                CommentComplaint mappedEntity = _mapper.Map<CommentComplaint>(request);
                CommentComplaint deleteCommentComplaint = await _commentcomplaintRepository.DeleteAsync(mappedEntity);
                ResponseDeleteCommentComplaintDto deletedCommentComplaintDto = _mapper.Map<ResponseDeleteCommentComplaintDto>(deleteCommentComplaint);
                return new SuccessDataResult<ResponseDeleteCommentComplaintDto>(deletedCommentComplaintDto, ResultMessages.Deleted);

            }


        }

    }
}
