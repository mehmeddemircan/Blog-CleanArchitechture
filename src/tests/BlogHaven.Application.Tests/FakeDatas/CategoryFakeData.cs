using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogHaven.Application.Tests.FakeDatas
{
    public class CategoryFakeData
    {
        public List<Category> GetCategories()
        {
            return new List<Category>
        {
            new Category { Id = 1, Name = "TestCategory1" },
            new Category { Id = 2, Name = "TestCategory2" },
        };
        }
    }
}
