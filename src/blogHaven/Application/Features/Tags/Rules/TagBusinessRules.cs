
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

namespace Application.Features.Tags.Rules
{
    public class TagBusinessRules 
    {
        private readonly ITagRepository _tagRepository;

        public TagBusinessRules(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task TagNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Tag> result = await _tagRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.TagNameExists);
            }
        }

        public void TagShouldExistWhenRequested(Tag tag)
        {
            if (tag == null)
            {
                throw new BusinessException(ExceptionMessages.TagShouldExistWhenRequested);
            }
        }
    }
}
