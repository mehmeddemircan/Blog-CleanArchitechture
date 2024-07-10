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

namespace Application.Features.BlogComplaints.Commands.Update
{
    public partial class UpdateBlogComplaintCommand : IRequest<IDataResult<ResponseUpdateBlogComplaintDto>>
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int ComplainerId { get; set; }
        public string Message { get; set; }
        public class UpdateBlogComplaintCommandHandler : IRequestHandler<UpdateBlogComplaintCommand, IDataResult<ResponseUpdateBlogComplaintDto>>
        {
            private readonly IBlogComplaintRepository _blogcomplaintRepository;
            private readonly IMapper _mapper;
            private readonly BlogComplaintBusinessRules _blogcomplaintBusinessRules;

            public UpdateBlogComplaintCommandHandler(IBlogComplaintRepository blogcomplaintRepository, IMapper mapper,
                                             BlogComplaintBusinessRules blogcomplaintBusinessRules)
            {
                _blogcomplaintRepository = blogcomplaintRepository;
                _mapper = mapper;
                _blogcomplaintBusinessRules = blogcomplaintBusinessRules;
            }

            public async Task<IDataResult<ResponseUpdateBlogComplaintDto>> Handle(UpdateBlogComplaintCommand request, CancellationToken cancellationToken)
            {



                BlogComplaint mappedEntity = _mapper.Map<BlogComplaint>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                BlogComplaint updateBlogComplaint = await _blogcomplaintRepository.UpdateAsync(mappedEntity);
                ResponseUpdateBlogComplaintDto updatedBlogComplaintDto = _mapper.Map<ResponseUpdateBlogComplaintDto>(updateBlogComplaint);
                return new SuccessDataResult<ResponseUpdateBlogComplaintDto>(updatedBlogComplaintDto, ResultMessages.Updated);
            }
        }
    }
}
