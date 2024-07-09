using Application.Constants;
using Application.Features.ContactUsMessages.Models;
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

namespace Application.Features.ContactUsMessages.Queries.GetList
{
    public class GetListContactUsMessageQuery : IRequest<IDataResult<ResponseContactUsMessageListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListContactUsMessageQueryHandler : IRequestHandler<GetListContactUsMessageQuery, IDataResult<ResponseContactUsMessageListModel>>
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;
            private readonly IMapper _mapper;

            public GetListContactUsMessageQueryHandler(IContactUsMessageRepository contactusmessageRepository, IMapper mapper)
            {
                _contactusmessageRepository = contactusmessageRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseContactUsMessageListModel>> Handle(GetListContactUsMessageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ContactUsMessage> categories = await _contactusmessageRepository.GetListAsync(include: source =>
                                                 source.Include(b => b.User),
                                               
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);

                ResponseContactUsMessageListModel mappedContactUsMessageListModel = _mapper.Map<ResponseContactUsMessageListModel>(categories);

                return new SuccessDataResult<ResponseContactUsMessageListModel>(mappedContactUsMessageListModel, ResultMessages.Listed);
            }
        }
    }
}
