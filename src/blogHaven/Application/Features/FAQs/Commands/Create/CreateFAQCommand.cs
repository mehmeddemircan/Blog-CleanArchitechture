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

namespace Application.Features.FAQs.Commands.Create
{
    public partial class CreateFAQCommand : IRequest<IDataResult<ResponseCreateFAQDto>>
    {

        public string Question { get; set; }

        public string? QuestionPhoto { get; set; }

        public string Answer { get; set; }

        public string? AnswerPhoto { get; set; }

        public class CreateFAQCommandHandler : IRequestHandler<CreateFAQCommand, IDataResult<ResponseCreateFAQDto>>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;
            private readonly FAQBusinessRules _faqBusinessRules;

            public CreateFAQCommandHandler(IFAQRepository faqRepository, IMapper mapper,
                                             FAQBusinessRules faqBusinessRules)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
                _faqBusinessRules = faqBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateFAQDto>> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
            {
                await _faqBusinessRules.FAQSameCanNotBeDuplicatedWhenInserted(request.Question, request.Answer);


                FAQ mappedEntity = _mapper.Map<FAQ>(request);
                FAQ createFAQ = await _faqRepository.AddAsync(mappedEntity);
                ResponseCreateFAQDto createdFAQDto = _mapper.Map<ResponseCreateFAQDto>(createFAQ);
                return new SuccessDataResult<ResponseCreateFAQDto>(createdFAQDto, ResultMessages.Added);
            }
        }
    }
}
