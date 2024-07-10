namespace Application.Features.CommentLikeDislikes.Dtos
{
    public class ResponseCommentLikeDislikeByIdDto : IDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsLiked { get; set; }
    }
}
