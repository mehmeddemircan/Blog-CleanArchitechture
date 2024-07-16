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

namespace Application.Features.FAQs.Rules
{
    public class FAQBusinessRules
    {
        private readonly IFAQRepository _faqRepository;

        public FAQBusinessRules(IFAQRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task FAQSameCanNotBeDuplicatedWhenInserted(string question, string answer)
        {
            IPaginate<FAQ> result = await _faqRepository.GetListAsync(b => b.Question == question && b.Answer == answer);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.FAQNameExists);
            }
        }
        public void FAQShouldExistWhenRequested(FAQ faq)
        {
            if (faq == null)
            {
                throw new BusinessException(ExceptionMessages.FAQShouldExistWhenRequested);
            }
        }
    }
}
