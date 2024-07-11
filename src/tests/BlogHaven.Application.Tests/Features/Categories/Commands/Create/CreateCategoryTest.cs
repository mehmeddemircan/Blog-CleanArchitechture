using Application.Constants;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Features.Categories.Validations;
using Application.Services.Repositories;
using AutoMapper;
using BlogHaven.Application.Tests.FakeDatas;
using BlogHaven.Application.Tests.MockRepositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Utilities.Results;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq; // Ensure this is included
using System.Linq.Expressions; // Ensure this is included
using System.Text;
using System.Threading.Tasks;

namespace BlogHaven.Application.Tests.Features.Categories.Commands.Create
{
    [TestFixture]
    public class CreateCategoryTest : CategoryMockRepository
    {
        private CreateCategoryCommandValidator _validator;
        private CreateCategoryCommand _command;
        private CreateCategoryCommand.CreateCategoryCommandHandler _handler;

        public CreateCategoryTest()
            : base(new CategoryFakeData())
        {
            _validator = new CreateCategoryCommandValidator();
            _command = new CreateCategoryCommand();
            _handler = new CreateCategoryCommand.CreateCategoryCommandHandler(MockRepository.Object, Mapper, BusinessRules);
        }

        [SetUp]
        public void Setup()
        {
            _command = new CreateCategoryCommand
            {
                Name = "TestCategory"
            };
        }

        [Test]
        public void CategoryNameEmptyShouldReturnError()
        {
            _command.Name = string.Empty;

            var result = _validator.Validate(_command);

            Assert.IsTrue(result.Errors.Any(x => x.PropertyName == "Name" && x.ErrorCode == "NotEmptyValidator"));
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessResult()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            Assert.IsInstanceOf<SuccessDataResult<ResponseCreateCategoryDto>>(result);
            Assert.AreEqual("TestCategory", result.Data.Name);
        }

     
    }
}
