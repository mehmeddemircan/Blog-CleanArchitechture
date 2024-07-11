namespace Application.Features.BlogFavorites.Dtos
{
    public class ResponseCreateBlogFavoriteDto : IDto
    {
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsFavorite { get; set; }
    }
}
