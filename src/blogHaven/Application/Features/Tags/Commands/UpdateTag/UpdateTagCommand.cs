using Application.Features.Categories.Dtos;
using Application.Features.Tags.Dtos;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Commands.UpdateTag
{
    public partial class UpdateTagCommand : IRequest<IDataResult<ResponseUpdateTagDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
