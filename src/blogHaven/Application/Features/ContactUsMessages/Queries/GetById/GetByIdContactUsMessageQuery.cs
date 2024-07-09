using Application.Constants;
using Application.Features.ContactUsMessages.Dtos;
using Application.Features.ContactUsMessages.Rules;
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

namespace Application.Features.ContactUsMessages.Queries.GetById
{
    public class GetByIdContactUsMessageQuery : IRequest<IDataResult<ResponseContactUsMessageByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdContactUsMessageQueryHandler : IRequestHandler<GetByIdContactUsMessageQuery, IDataResult<ResponseContactUsMessageByIdDto>>
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;
            private readonly IMapper _mapper;
            private readonly ContactUsMessageBusinessRules _contactusmessageBusinessRules;

            public GetByIdContactUsMessageQueryHandler(IContactUsMessageRepository contactusmessageRepository, IMapper mapper, ContactUsMessageBusinessRules contactusmessageBusinessRules)
            {
                _contactusmessageRepository = contactusmessageRepository;
                _mapper = mapper;
                _contactusmessageBusinessRules = contactusmessageBusinessRules;
            }

            public async Task<IDataResult<ResponseContactUsMessageByIdDto>> Handle(GetByIdContactUsMessageQuery request, CancellationToken cancellationToken)
            {
                ContactUsMessage? contactusmessage = await _contactusmessageRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.User);

                _contactusmessageBusinessRules.ContactUsMessageShouldExistWhenRequested(contactusmessage);

                ResponseContactUsMessageByIdDto contactusmessageGetByIdDto = _mapper.Map<ResponseContactUsMessageByIdDto>(contactusmessage);
                return new SuccessDataResult<ResponseContactUsMessageByIdDto>(contactusmessageGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
