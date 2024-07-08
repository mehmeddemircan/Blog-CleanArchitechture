using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public partial class CreateCategoryCommand : IRequest<ResponseCreateCategoryDto>
    {
        public string Name { get; set; }
    }
}
