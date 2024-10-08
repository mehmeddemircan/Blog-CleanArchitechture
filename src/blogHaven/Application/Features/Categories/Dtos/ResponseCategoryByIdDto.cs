﻿using Application.Features.Tags.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Dtos
{
    public class ResponseCategoryByIdDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ResponseTagListDto> Tags { get; set; }
    }
}
