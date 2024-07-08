using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.ResultMessages;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public partial class CreateCategoryCommand
    {
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IDataResult<ResponseCreateCategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                             CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);


                Category mappedEntity = _mapper.Map<Category>(request);
                Category createCategory = await _categoryRepository.AddAsync(mappedEntity);
                ResponseCreateCategoryDto createdCategoryDto = _mapper.Map<ResponseCreateCategoryDto>(createCategory);
                return new SuccessDataResult<ResponseCreateCategoryDto>(createdCategoryDto, Messages.Added); 
            }
        }
    }
}
