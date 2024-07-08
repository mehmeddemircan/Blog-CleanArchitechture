using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ValidationMessages
    {

        #region Category
        public const string CategoryNameCanNotBeEmpty = "Category Name Can not be empty";
        public const string CategoryNameMinLength = "Category Name minimum length 2 character ";
        #endregion


        #region Tag
        public const string TagNameCanNotBeEmpty = "Tag Name Can not be empty";
        public const string TagNameMinLength = "Tag Name minimum length 2 character ";
        #endregion
    }
}
