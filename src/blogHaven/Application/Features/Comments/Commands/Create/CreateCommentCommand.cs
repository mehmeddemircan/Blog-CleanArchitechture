using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.Comments.Commands.Create
{
    public partial class CreateCommentCommand : IRequest<IDataResult<ResponseCreateCommentDto>>
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }

        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, IDataResult<ResponseCreateCommentDto>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
            private readonly CommentBusinessRules _commentBusinessRules;

            public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper,
                                             CommentBusinessRules commentBusinessRules)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _commentBusinessRules = commentBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateCommentDto>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {

                //Todo : Aynı kullanıcı bir bloga en fazla 5 yorum yapabilir 
                await _commentBusinessRules.OneUserCanAddFiveCommentToSameBlog(request.BlogId, request.UserId); 

                Comment mappedEntity = _mapper.Map<Comment>(request);
                Comment createComment = await _commentRepository.AddAsync(mappedEntity);
                ResponseCreateCommentDto createdCommentDto = _mapper.Map<ResponseCreateCommentDto>(createComment);
                return new SuccessDataResult<ResponseCreateCommentDto>(createdCommentDto, ResultMessages.Added);
            }
        }
    }
}
