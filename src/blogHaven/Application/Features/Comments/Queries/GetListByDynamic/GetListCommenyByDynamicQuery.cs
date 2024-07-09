using Application.Constants;
using Application.Features.Comments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace Application.Features.Comments.Queries.GetListByDynamic
{
    public class GetListCommentByDynamicQuery : IRequest<IDataResult<ResponseCommentListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListCommentByDynamicQueryHandler : IRequestHandler<GetListCommentByDynamicQuery, IDataResult<ResponseCommentListModel>>
        {

            private readonly IMapper _mapper;
            private readonly ICommentRepository _commentRepository;

            public GetListCommentByDynamicQueryHandler(IMapper mapper, ICommentRepository commentRepository)
            {
                _mapper = mapper;
                _commentRepository = commentRepository;
            }

            public async Task<IDataResult<ResponseCommentListModel>> Handle(GetListCommentByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<Comment> comments = await _commentRepository.GetListByDynamicAsync(request.Dynamic,
                                              include: query => query.Include(b => b.Blog).Include(b => b.User),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseCommentListModel mappedComments = _mapper.Map<ResponseCommentListModel>(comments);
                return new SuccessDataResult<ResponseCommentListModel>(mappedComments, ResultMessages.Listed);
            }
        }
    }
}
