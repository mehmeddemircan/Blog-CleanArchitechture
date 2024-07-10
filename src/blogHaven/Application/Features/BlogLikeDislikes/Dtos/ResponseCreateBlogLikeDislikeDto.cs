namespace Application.Features.BlogLikeDislikes.Dtos
{
    public class ResponseCreateBlogLikeDislikeDto : IDto
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsLiked { get; set; }
    }

}
