using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContactUsMessages.Rules
{
  
        public class ContactUsMessageBusinessRules
        {
            private readonly IContactUsMessageRepository _contactusmessageRepository;

            public ContactUsMessageBusinessRules(IContactUsMessageRepository contactusmessageRepository)
            {
                _contactusmessageRepository = contactusmessageRepository;
            }

            public void ContactUsMessageShouldExistWhenRequested(ContactUsMessage contactusmessage)
            {
                if (contactusmessage == null)
                {
                    throw new BusinessException(ExceptionMessages.ContactUsMessageShouldExistWhenRequested);
                }
            }
        }
    
}
