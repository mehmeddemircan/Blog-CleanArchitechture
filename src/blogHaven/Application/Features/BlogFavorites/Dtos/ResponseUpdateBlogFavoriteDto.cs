namespace Application.Features.BlogFavorites.Dtos
{
    public class ResponseUpdateBlogFavoriteDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime ActionedOn { get; set; }
        public bool IsFavorite { get; set; }
    }
}
