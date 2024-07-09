using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Rules
{
    public class BlogBusinessRules
    {
        private readonly IBlogRepository _blogRepository;

        public BlogBusinessRules(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task BlogNameCanNotBeDuplicatedWhenInserted(string title)
        {
            IPaginate<Blog> result = await _blogRepository.GetListAsync(b => b.Title == title);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.BlogNameExists);
            }
        }

        public void BlogShouldExistWhenRequested(Blog blog)
        {
            if (blog == null)
            {
                throw new BusinessException(ExceptionMessages.BlogShouldExistWhenRequested);
            }
        }
    }
}
