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

namespace Application.Features.Comments.Commands.Update
{
    public partial class UpdateCommentCommand : IRequest<IDataResult<ResponseUpdateCommentDto>>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, IDataResult<ResponseUpdateCommentDto>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper,
                                             CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateCommentDto>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                
                Comment mappedEntity = _mapper.Map<Comment>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Comment updateComment = await _commentRepository.UpdateAsync(mappedEntity);
                ResponseUpdateCommentDto updatedCommentDto = _mapper.Map<ResponseUpdateCommentDto>(updateComment);
                return new SuccessDataResult<ResponseUpdateCommentDto>(updatedCommentDto, ResultMessages.Updated);
            }
        }
    }
}
