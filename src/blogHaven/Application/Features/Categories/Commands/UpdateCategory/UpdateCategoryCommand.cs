using Application.Features.Categories.Dtos;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public partial class UpdateCategoryCommand : IRequest<IDataResult<ResponseUpdateCategoryDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
