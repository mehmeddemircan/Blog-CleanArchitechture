using Application.Constants;
using Application.Features.BlogTags.Dtos;
using Application.Features.BlogTags.Rules;
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

namespace Application.Features.BlogTags.Commands.Create
{
    public partial class CreateBlogTagCommand : IRequest<IDataResult<ResponseCreateBlogTagDto>>
    {
        public int BlogId { get; set; }

        public int TagId { get; set; }
        public class CreateBlogTagCommandHandler : IRequestHandler<CreateBlogTagCommand, IDataResult<ResponseCreateBlogTagDto>>
        {
            private readonly IBlogTagRepository _blogtagRepository;
            private readonly IMapper _mapper;
            private readonly BlogTagBusinessRules _blogtagBusinessRules;

            public CreateBlogTagCommandHandler(IBlogTagRepository blogtagRepository, IMapper mapper,
                                             BlogTagBusinessRules blogtagBusinessRules)
            {
                _blogtagRepository = blogtagRepository;
                _mapper = mapper;
                _blogtagBusinessRules = blogtagBusinessRules;
            }

            public async Task<IDataResult<ResponseCreateBlogTagDto>> Handle(CreateBlogTagCommand request, CancellationToken cancellationToken)
            {
                
                //Todo : Aynı bloga aynı tagdan iki kere eklenemez iş kuralı 


                BlogTag mappedEntity = _mapper.Map<BlogTag>(request);
                BlogTag createBlogTag = await _blogtagRepository.AddAsync(mappedEntity);
                ResponseCreateBlogTagDto createdBlogTagDto = _mapper.Map<ResponseCreateBlogTagDto>(createBlogTag);
                return new SuccessDataResult<ResponseCreateBlogTagDto>(createdBlogTagDto, ResultMessages.Added);
            }
        }
    }
}
