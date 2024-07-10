namespace Application.Features.CommentLikeDislikes.Dtos
{
    public class ResponseCreateCommentLikeDislikeDto  : IDto
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsLiked { get; set; }
    }
}
