using Application.Features.Categories.Commands.DeleteCategory;
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

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public partial class DeleteCategoryCommand : IRequest<IDataResult<ResponseDeleteCategoryDto>>
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IDataResult<ResponseDeleteCategoryDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper,
                                             CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteCategoryDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category mappedEntity = _mapper.Map<Category>(request);
                Category deleteCategory = await _categoryRepository.DeleteAsync(mappedEntity);
                ResponseDeleteCategoryDto deletedCategoryDto = _mapper.Map<ResponseDeleteCategoryDto>(deleteCategory);
                return new SuccessDataResult<ResponseDeleteCategoryDto>(deletedCategoryDto, Messages.Deleted);

            }


        }

    }
   
}
