using Application.Constants;
using Application.Features.FAQs.Dtos;
using Application.Features.FAQs.Rules;
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

namespace Application.Features.FAQs.Queries.GetById
{
    public class GetByIdFAQQuery : IRequest<IDataResult<ResponseFAQByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdFAQQueryHandler : IRequestHandler<GetByIdFAQQuery, IDataResult<ResponseFAQByIdDto>>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;
            private readonly FAQBusinessRules _faqBusinessRules;

            public GetByIdFAQQueryHandler(IFAQRepository faqRepository, IMapper mapper, FAQBusinessRules faqBusinessRules)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
                _faqBusinessRules = faqBusinessRules;
            }

            public async Task<IDataResult<ResponseFAQByIdDto>> Handle(GetByIdFAQQuery request, CancellationToken cancellationToken)
            {
                FAQ? faq = await _faqRepository.GetAsync(b => b.Id == request.Id);

                _faqBusinessRules.FAQShouldExistWhenRequested(faq);

                ResponseFAQByIdDto faqGetByIdDto = _mapper.Map<ResponseFAQByIdDto>(faq);
                return new SuccessDataResult<ResponseFAQByIdDto>(faqGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
