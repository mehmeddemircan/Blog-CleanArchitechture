using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public partial class UpdateCategoryCommand : IRequest<ResponseUpdateCategoryDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
