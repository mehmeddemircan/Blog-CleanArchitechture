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

namespace Application.Features.CommentComplaints.Queries.GetById
{
    public class GetByIdCommentComplaintQuery : IRequest<IDataResult<ResponseCommentComplaintByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdCommentComplaintQueryHandler : IRequestHandler<GetByIdCommentComplaintQuery, IDataResult<ResponseCommentComplaintByIdDto>>
        {
            private readonly ICommentComplaintRepository _commentcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly CommentComplaintBusinessRules _commentcomplaintBusinessRules;

            public GetByIdCommentComplaintQueryHandler(ICommentComplaintRepository commentcomplaintRepository, IMapper mapper, CommentComplaintBusinessRules commentcomplaintBusinessRules)
            {
                _commentcomplaintRepository = commentcomplaintRepository;
                _mapper = mapper;
                _commentcomplaintBusinessRules = commentcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseCommentComplaintByIdDto>> Handle(GetByIdCommentComplaintQuery request, CancellationToken cancellationToken)
            {
                CommentComplaint? commentcomplaint = await _commentcomplaintRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Complainer, b => b.Comment);

                _commentcomplaintBusinessRules.CommentComplaintShouldExistWhenRequested(commentcomplaint);

                ResponseCommentComplaintByIdDto commentcomplaintGetByIdDto = _mapper.Map<ResponseCommentComplaintByIdDto>(commentcomplaint);
                return new SuccessDataResult<ResponseCommentComplaintByIdDto>(commentcomplaintGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
