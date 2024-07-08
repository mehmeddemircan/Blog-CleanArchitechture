using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Constants
{
    public static class CategoryExceptionConstants
    {
        public const string CategoryNameExists = "Category Name Already exists";
        public const string CategoryShouldExistWhenRequested = "Requested brand does not exist";
    }
}
