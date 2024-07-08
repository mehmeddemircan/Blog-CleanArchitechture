using Application.Features.Categories.Dtos;
using Application.Features.Tags.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tags.Commands.CreateTag
{
    public partial class CreateTagCommand : IRequest<ResponseCreateTagDto>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
