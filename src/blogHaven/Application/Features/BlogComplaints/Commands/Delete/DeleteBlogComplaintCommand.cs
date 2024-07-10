using Application.Constants;
using Application.Features.BlogComplaints.Dtos;
using Application.Features.BlogComplaints.Rules;
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

namespace Application.Features.BlogComplaints.Commands.Delete
{
    public partial class DeleteBlogComplaintCommand : IRequest<IDataResult<ResponseDeleteBlogComplaintDto>>
    {
        public int Id { get; set; }

        public class DeleteBlogComplaintCommandHandler : IRequestHandler<DeleteBlogComplaintCommand, IDataResult<ResponseDeleteBlogComplaintDto>>
        {
            private readonly IBlogComplaintRepository _blogcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly BlogComplaintBusinessRules _blogcomplaintBusinessRules;

            public DeleteBlogComplaintCommandHandler(IBlogComplaintRepository blogcomplaintRepository, IMapper mapper,
                                             BlogComplaintBusinessRules blogcomplaintBusinessRules)
            {
                _blogcomplaintRepository = blogcomplaintRepository;
                _mapper = mapper;
                _blogcomplaintBusinessRules = blogcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseDeleteBlogComplaintDto>> Handle(DeleteBlogComplaintCommand request, CancellationToken cancellationToken)
            {
                BlogComplaint mappedEntity = _mapper.Map<BlogComplaint>(request);
                BlogComplaint deleteBlogComplaint = await _blogcomplaintRepository.DeleteAsync(mappedEntity);
                ResponseDeleteBlogComplaintDto deletedBlogComplaintDto = _mapper.Map<ResponseDeleteBlogComplaintDto>(deleteBlogComplaint);
                return new SuccessDataResult<ResponseDeleteBlogComplaintDto>(deletedBlogComplaintDto, ResultMessages.Deleted);

            }


        }

    }
}
