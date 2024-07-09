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

namespace Application.Features.ContactUsMessages.Commands.Delete
{
    public partial class DeleteContactUsMessageCommand : IRequest<IDataResult<ResponseDeleteContactUsMessageDto>>
    {
        public int Id { get; set; }

        public class DeleteContactUsMessageCommandHandler : IRequestHandler<DeleteContactUsMessageCommand, IDataResult<ResponseDeleteContactUsMessageDto>>
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;
            private readonly IMapper _mapper;
            private readonly ContactUsMessageBusinessRules _contactusmessageBusinessRules;

            public DeleteContactUsMessageCommandHandler(IContactUsMessageRepository contactusmessageRepository, IMapper mapper,
                                             ContactUsMessageBusinessRules contactusmessageBusinessRules)
            {
                _contactusmessageRepository = contactusmessageRepository;
                _mapper = mapper;
                _contactusmessageBusinessRules = contactusmessageBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteContactUsMessageDto>> Handle(DeleteContactUsMessageCommand request, CancellationToken cancellationToken)
            {
                ContactUsMessage mappedEntity = _mapper.Map<ContactUsMessage>(request);
                ContactUsMessage deleteContactUsMessage = await _contactusmessageRepository.DeleteAsync(mappedEntity);
                ResponseDeleteContactUsMessageDto deletedContactUsMessageDto = _mapper.Map<ResponseDeleteContactUsMessageDto>(deleteContactUsMessage);
                return new SuccessDataResult<ResponseDeleteContactUsMessageDto>(deletedContactUsMessageDto, ResultMessages.Deleted);

            }


        }

    }
}
