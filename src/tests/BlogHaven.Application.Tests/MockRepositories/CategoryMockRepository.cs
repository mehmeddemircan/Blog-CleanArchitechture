using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using BlogHaven.Application.Tests.FakeDatas;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Moq.Language.Flow; // Bu using direktifini eklemeyi unutmayın
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogHaven.Application.Tests.MockRepositories
{
    public class CategoryMockRepository
    {
        protected Mock<ICategoryRepository> MockRepository;
        protected IMapper Mapper;
        protected CategoryBusinessRules BusinessRules;

        public CategoryMockRepository(CategoryFakeData fakeData)
        {
            var categories = fakeData.GetCategories();

            var mockPaginate = new Mock<IPaginate<Category>>();
            mockPaginate.Setup(p => p.Items).Returns(categories);

            MockRepository = new Mock<ICategoryRepository>();
            


            MockRepository.Setup(r => r.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) => category);

            // Setup AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateCategoryCommand, Category>();
                cfg.CreateMap<Category, ResponseCreateCategoryDto>();
            });
            Mapper = config.CreateMapper();

            BusinessRules = new CategoryBusinessRules(MockRepository.Object);
        }
    }
}
