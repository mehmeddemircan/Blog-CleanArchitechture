using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ExceptionMessages
    {

        #region Category
        public const string CategoryNameExists = "Category Name Already exists";
        public const string CategoryShouldExistWhenRequested = "Requested brand does not exist";
        #endregion


        #region OperationClaim
        public const string OperationClaimNameExists = "OperationClaim Name Already exists";
        public const string OperationClaimShouldExistWhenRequested = "Requested OperationClaim does not exist";
        #endregion

        #region Tag
        public const string TagNameExists = "Tag Name Already exists";
        public const string TagShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region UserOperationClaim
        public const string UserOperationClaimNameExists = "UserOperationClaim Name Already exists";
        public const string UserOperationClaimShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region User
        public const string UserShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region Blog
        public const string BlogNameExists = "Blog Name Already exists";
        public const string BlogShouldExistWhenRequested = "Requested brand does not exist";
        #endregion

        #region Comment
        public const string OneUserCanAddFiveComment = "A user can only add up to five comments to a blog.";
        public const string CommentShouldExistWhenRequested = "Requested Comment does not exist";
        #endregion

        #region BlogTag

        public const string BlogTagExists = "Blog Tag Already exists";
        #endregion

        #region ContactUsMessage

        public const string ContactUsMessageShouldExistWhenRequested = "Requested Contact Us Message does not exist";
        #endregion
    }
}
