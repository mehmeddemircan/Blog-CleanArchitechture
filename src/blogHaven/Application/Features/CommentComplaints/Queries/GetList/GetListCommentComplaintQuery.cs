using Application.Constants;
using Application.Features.CommentComplaints.Models;
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

namespace Application.Features.CommentComplaints.Queries.GetList
{
    public class GetListCommentComplaintQuery : IRequest<IDataResult<ResponseCommentComplaintListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCommentComplaintQueryHandler : IRequestHandler<GetListCommentComplaintQuery, IDataResult<ResponseCommentComplaintListModel>>
        {
            private readonly ICommentComplaintRepository _commentcomplaintRepository;
            private readonly IMapper _mapper;

            public GetListCommentComplaintQueryHandler(ICommentComplaintRepository commentcomplaintRepository, IMapper mapper)
            {
                _commentcomplaintRepository = commentcomplaintRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseCommentComplaintListModel>> Handle(GetListCommentComplaintQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CommentComplaint> categories = await _commentcomplaintRepository.GetListAsync(include: source =>
                                                 source.Include(b => b.Complainer)
                                                .Include(b => b.Comment),
                                               
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);

                ResponseCommentComplaintListModel mappedCommentComplaintListModel = _mapper.Map<ResponseCommentComplaintListModel>(categories);

                return new SuccessDataResult<ResponseCommentComplaintListModel>(mappedCommentComplaintListModel, ResultMessages.Listed);
            }
        }
    }
}
