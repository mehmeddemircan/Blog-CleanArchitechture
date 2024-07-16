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

namespace Application.Features.FAQs.Commands.Delete
{
    public partial class DeleteFAQCommand : IRequest<IDataResult<ResponseDeleteFAQDto>>
    {
        public int Id { get; set; }

        public class DeleteFAQCommandHandler : IRequestHandler<DeleteFAQCommand, IDataResult<ResponseDeleteFAQDto>>
        {
            private readonly IFAQRepository _faqRepository;
            private readonly IMapper _mapper;
            private readonly FAQBusinessRules _faqBusinessRules;

            public DeleteFAQCommandHandler(IFAQRepository faqRepository, IMapper mapper,
                                             FAQBusinessRules faqBusinessRules)
            {
                _faqRepository = faqRepository;
                _mapper = mapper;
                _faqBusinessRules = faqBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteFAQDto>> Handle(DeleteFAQCommand request, CancellationToken cancellationToken)
            {
                FAQ mappedEntity = _mapper.Map<FAQ>(request);
                FAQ deleteFAQ = await _faqRepository.DeleteAsync(mappedEntity);
                ResponseDeleteFAQDto deletedFAQDto = _mapper.Map<ResponseDeleteFAQDto>(deleteFAQ);
                return new SuccessDataResult<ResponseDeleteFAQDto>(deletedFAQDto, ResultMessages.Deleted);

            }


        }

    }
}
