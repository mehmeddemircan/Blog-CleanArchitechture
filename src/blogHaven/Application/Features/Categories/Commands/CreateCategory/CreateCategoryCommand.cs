﻿using Application.Features.Categories.Dtos;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public partial class CreateCategoryCommand : IRequest<IDataResult<ResponseCreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
