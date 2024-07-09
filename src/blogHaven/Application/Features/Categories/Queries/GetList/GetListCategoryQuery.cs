using Application.Constants;
using Application.Features.Categories.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetListCategory
{
    public class GetListCategoryQuery  : IRequest<IDataResult<ResponseCategoryListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, IDataResult<ResponseCategoryListModel>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<ResponseCategoryListModel>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Category> categories = await _categoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ResponseCategoryListModel mappedCategoryListModel = _mapper.Map<ResponseCategoryListModel>(categories);

                return new SuccessDataResult<ResponseCategoryListModel>(mappedCategoryListModel,ResultMessages.Listed);
            }
        }
    }
}
