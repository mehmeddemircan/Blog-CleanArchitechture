using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
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

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public partial class DeleteCategoryCommand : IRequest<IDataResult<ResponseDeleteCategoryDto>>
    {
        public int Id { get; set; }

       
    }
   
}
