using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogTags.Rules
{
    public class BlogTagBusinessRules
    {
        private readonly IBlogTagRepository _blogtagRepository;

        public BlogTagBusinessRules(IBlogTagRepository blogtagRepository)
        {
            _blogtagRepository = blogtagRepository;
        }

        public async Task BlogTagCanNotBeDuplicatedWhenInserted(int blogId, int tagId)
        {
            IPaginate<BlogTag> result = await _blogtagRepository.GetListAsync(b => b.BlogId == blogId &&  b.TagId == tagId);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.BlogTagExists);
            }
        }
    }
}
