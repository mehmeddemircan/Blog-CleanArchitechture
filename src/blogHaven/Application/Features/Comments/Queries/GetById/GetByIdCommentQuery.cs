using Application.Constants;
using Application.Features.Comments.Dtos;
using Application.Features.Comments.Rules;
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

namespace Application.Features.Comments.Queries.GetById
{
    public class GetByIdCommentQuery : IRequest<IDataResult<ResponseCommentByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, IDataResult<ResponseCommentByIdDto>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<IDataResult<ResponseCommentByIdDto>> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
            {
                Comment? comment = await _commentRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.User, b => b.Blog);

                _commentBusinessRules.CommentShouldExistWhenRequested(comment);

                ResponseCommentByIdDto commentGetByIdDto = _mapper.Map<ResponseCommentByIdDto>(comment);
                return new SuccessDataResult<ResponseCommentByIdDto>(commentGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
