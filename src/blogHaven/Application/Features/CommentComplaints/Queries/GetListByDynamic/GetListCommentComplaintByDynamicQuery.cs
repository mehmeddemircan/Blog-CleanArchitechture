using Application.Constants;
using Application.Features.CommentComplaints.Models;
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

namespace Application.Features.CommentComplaints.Queries.GetListByDynamic
{
    public class GetListCommentComplaintByDynamicQuery : IRequest<IDataResult<ResponseCommentComplaintListModel>>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListCommentComplaintByDynamicQueryHandler : IRequestHandler<GetListCommentComplaintByDynamicQuery, IDataResult<ResponseCommentComplaintListModel>>
        {

            private readonly IMapper _mapper;
            private readonly ICommentComplaintRepository _commentcomplaintRepository;

            public GetListCommentComplaintByDynamicQueryHandler(IMapper mapper, ICommentComplaintRepository commentcomplaintRepository)
            {
                _mapper = mapper;
                _commentcomplaintRepository = commentcomplaintRepository;
            }

            public async Task<IDataResult<ResponseCommentComplaintListModel>> Handle(GetListCommentComplaintByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<CommentComplaint> commentcomplaints = await _commentcomplaintRepository.GetListByDynamicAsync(request.Dynamic,
                                              include: query => query.Include(b => b.Complainer).Include(b => b.Comment),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );

                ResponseCommentComplaintListModel mappedCommentComplaints = _mapper.Map<ResponseCommentComplaintListModel>(commentcomplaints);
                return new SuccessDataResult<ResponseCommentComplaintListModel>(mappedCommentComplaints, ResultMessages.Listed);
            }
        }
    }
}
