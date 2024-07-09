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

namespace Application.Features.ContactUsMessages.Commands.Update
{
    public partial class UpdateContactUsMessageCommand : IRequest<IDataResult<ResponseUpdateContactUsMessageDto>>
    {
        public int Id { get; set; }

        public string Topic { get; set; }
        public string Content { get; set; }
        public int? UserId { get; set; }
        public class UpdateContactUsMessageCommandHandler : IRequestHandler<UpdateContactUsMessageCommand, IDataResult<ResponseUpdateContactUsMessageDto>>
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;
            private readonly IMapper _mapper;
            private readonly ContactUsMessageBusinessRules _contactusmessageBusinessRules;

            public UpdateContactUsMessageCommandHandler(IContactUsMessageRepository contactusmessageRepository, IMapper mapper,
                                             ContactUsMessageBusinessRules contactusmessageBusinessRules)
            {
                _contactusmessageRepository = contactusmessageRepository;
                _mapper = mapper;
                _contactusmessageBusinessRules = contactusmessageBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateContactUsMessageDto>> Handle(UpdateContactUsMessageCommand request, CancellationToken cancellationToken)
            {

                ContactUsMessage mappedEntity = _mapper.Map<ContactUsMessage>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                ContactUsMessage updateContactUsMessage = await _contactusmessageRepository.UpdateAsync(mappedEntity);
                ResponseUpdateContactUsMessageDto updatedContactUsMessageDto = _mapper.Map<ResponseUpdateContactUsMessageDto>(updateContactUsMessage);
                return new SuccessDataResult<ResponseUpdateContactUsMessageDto>(updatedContactUsMessageDto, ResultMessages.Updated);
            }
        }
    }
}
