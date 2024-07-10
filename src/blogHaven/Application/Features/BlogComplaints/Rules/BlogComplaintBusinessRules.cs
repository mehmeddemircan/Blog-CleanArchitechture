using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComplaints.Rules
{
    public class BlogComplaintBusinessRules
    {
        private readonly IBlogComplaintRepository _blogcomplaintRepository;

        public BlogComplaintBusinessRules(IBlogComplaintRepository blogcomplaintRepository)
        {
            _blogcomplaintRepository = blogcomplaintRepository;
        }
        public void BlogComplaintShouldExistWhenRequested(BlogComplaint blogcomplaint)
        {
            if (blogcomplaint == null)
            {
                throw new BusinessException(ExceptionMessages.BlogComplaintShouldExistWhenRequested);
            }
        }
    }
}

