using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CommentComplaints.Rules
{
    public class CommentComplaintBusinessRules
    {
        private readonly ICommentComplaintRepository _commentcomplaintRepository;

        public CommentComplaintBusinessRules(ICommentComplaintRepository commentcomplaintRepository)
        {
            _commentcomplaintRepository = commentcomplaintRepository;
        }
        public void CommentComplaintShouldExistWhenRequested(CommentComplaint commentcomplaint)
        {
            if (commentcomplaint == null)
            {
                throw new BusinessException(ExceptionMessages.CommentComplaintShouldExistWhenRequested);
            }
        }
    }
}
