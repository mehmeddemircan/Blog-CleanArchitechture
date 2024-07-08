using Application.Features.Categories.Dtos;
using Application.Features.Tags.Dtos;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Commands.DeleteTag
{
    public partial class DeleteTagCommand : IRequest<IDataResult<ResponseDeleteTagDto>>
    {
        public int Id { get; set; }


    }
}
