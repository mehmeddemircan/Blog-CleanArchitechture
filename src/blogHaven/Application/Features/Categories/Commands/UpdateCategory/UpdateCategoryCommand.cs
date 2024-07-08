using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.ResultMessages;
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

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public partial class UpdateCategoryCommand : IRequest<IDataResult<ResponseUpdateCategoryDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IDataResult<ResponseUpdateCategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                             CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);


                Category mappedEntity = _mapper.Map<Category>(request);
                Category updateCategory = await _categoryRepository.UpdateAsync(mappedEntity);
                ResponseUpdateCategoryDto updatedCategoryDto = _mapper.Map<ResponseUpdateCategoryDto>(updateCategory);
                return new SuccessDataResult<ResponseUpdateCategoryDto>(updatedCategoryDto, Messages.Updated);
            }
        }
    }
}
