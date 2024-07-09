using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.ContactUsMessages.Commands.Create
{
    public partial class CreateContactUsMessageCommand : IRequest<IDataResult<ResponseCreateContactUsMessageDto>>
    {
        public string Topic { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }

        public class CreateContactUsMessageCommandHandler : IRequestHandler<CreateContactUsMessageCommand, IDataResult<ResponseCreateContactUsMessageDto>>
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;
            private readonly IMapper _mapper;
            private readonly ContactUsMessageBusinessRules _contactusmessageBusinessRules;

            public CreateContactUsMessageCommandHandler(IContactUsMessageRepository contactusmessageRepository, IMapper mapper,
                                             ContactUsMessageBusinessRules contactusmessageBusinessRules)
            {
                _contactusmessageRepository = contactusmessageRepository;
                _mapper = mapper;
                _contactusmessageBusinessRules = contactusmessageBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateContactUsMessageDto>> Handle(CreateContactUsMessageCommand request, CancellationToken cancellationToken)
            {
                //await _contactusmessageBusinessRules.ContactUsMessageNameCanNotBeDuplicatedWhenInserted(request.Name);


                ContactUsMessage mappedEntity = _mapper.Map<ContactUsMessage>(request);
                ContactUsMessage createContactUsMessage = await _contactusmessageRepository.AddAsync(mappedEntity);
                ResponseCreateContactUsMessageDto createdContactUsMessageDto = _mapper.Map<ResponseCreateContactUsMessageDto>(createContactUsMessage);
                return new SuccessDataResult<ResponseCreateContactUsMessageDto>(createdContactUsMessageDto, ResultMessages.Added);
            }
        }
    }
}
