using Application.Constants;
using Application.Features.FAQs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FAQs.Queries.GetList
{
    public class GetListFAQQuery : IRequest<IDataResult<ResponseFAQListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListFAQQueryHandler : IRequestHandler<GetListFAQQuery, IDataResult<ResponseFAQListModel>>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;

            public GetListFAQQueryHandler(IFAQRepository faqRepository, IMapper mapper)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseFAQListModel>> Handle(GetListFAQQuery request, CancellationToken cancellationToken)
            {
                IPaginate<FAQ> categories = await _faqRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ResponseFAQListModel mappedFAQListModel = _mapper.Map<ResponseFAQListModel>(categories);

                return new SuccessDataResult<ResponseFAQListModel>(mappedFAQListModel, ResultMessages.Listed);
            }
        }
    }
}
