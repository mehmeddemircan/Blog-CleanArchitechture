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

namespace Application.Features.Comments.Commands.Delete
{
    public partial class DeleteCommentCommand : IRequest<IDataResult<ResponseDeleteCommentDto>>
    {
        public int Id { get; set; }

        public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, IDataResult<ResponseDeleteCommentDto>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper,
                                             CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteCommentDto>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                Comment mappedEntity = _mapper.Map<Comment>(request);
                Comment deleteComment = await _commentRepository.DeleteAsync(mappedEntity);
                ResponseDeleteCommentDto deletedCommentDto = _mapper.Map<ResponseDeleteCommentDto>(deleteComment);
                return new SuccessDataResult<ResponseDeleteCommentDto>(deletedCommentDto, ResultMessages.Deleted);

            }


        }

    }
}
