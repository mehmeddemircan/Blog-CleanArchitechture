using Application.Constants;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQuery : IRequest<IDataResult<ResponseCategoryByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, IDataResult<ResponseCategoryByIdDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<ResponseCategoryByIdDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.Tags);

                _categoryBusinessRules.CategoryShouldExistWhenRequested(category);

                ResponseCategoryByIdDto categoryGetByIdDto = _mapper.Map<ResponseCategoryByIdDto>(category);
                return new SuccessDataResult<ResponseCategoryByIdDto>(categoryGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
