using Application.Constants;
using Application.Features.Comments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Queries.GetListByBlogId
{
    public class GetListCommentByBlogIdQuery : IRequest<IDataResult<ResponseCommentListModel>>
    {
        public int BlogId { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListCommentQueryHandler : IRequestHandler<GetListCommentByBlogIdQuery, IDataResult<ResponseCommentListModel>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;

            public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseCommentListModel>> Handle(GetListCommentByBlogIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Comment> categories = await _commentRepository.GetListAsync(predicate: c => c.BlogId == request.BlogId && c.ParentId == null, include: source =>
                                                 source.Include(b => b.User)
                                                .Include(b => b.Blog),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);

                ResponseCommentListModel mappedCommentListModel = _mapper.Map<ResponseCommentListModel>(categories);

                return new SuccessDataResult<ResponseCommentListModel>(mappedCommentListModel, ResultMessages.Listed);
            }
        }
    }
}
