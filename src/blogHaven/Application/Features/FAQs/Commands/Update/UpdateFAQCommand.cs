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

namespace Application.Features.FAQs.Commands.Update
{
    public partial class UpdateFAQCommand : IRequest<IDataResult<ResponseUpdateFAQDto>>
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string? QuestionPhoto { get; set; }

        public string Answer { get; set; }

        public string? AnswerPhoto { get; set; }

        public class UpdateFAQCommandHandler : IRequestHandler<UpdateFAQCommand, IDataResult<ResponseUpdateFAQDto>>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;
            private readonly FAQBusinessRules _faqBusinessRules;

            public UpdateFAQCommandHandler(IFAQRepository faqRepository, IMapper mapper,
                                             FAQBusinessRules faqBusinessRules)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
                _faqBusinessRules = faqBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateFAQDto>> Handle(UpdateFAQCommand request, CancellationToken cancellationToken)
            {
                await _faqBusinessRules.FAQSameCanNotBeDuplicatedWhenInserted(request.Question, request.Answer);


                FAQ mappedEntity = _mapper.Map<FAQ>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                FAQ updateFAQ = await _faqRepository.UpdateAsync(mappedEntity);
                ResponseUpdateFAQDto updatedFAQDto = _mapper.Map<ResponseUpdateFAQDto>(updateFAQ);
                return new SuccessDataResult<ResponseUpdateFAQDto>(updatedFAQDto, ResultMessages.Updated);
            }
        }
    }
}
