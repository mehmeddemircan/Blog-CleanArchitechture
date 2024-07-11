namespace Application.Features.BlogFavorites.Dtos
{
    public class ResponseBlogFavoriteByIdDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogThumbNailImage { get; set; }
        public string CategoryName { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int UserId { get; set; }
     
        public DateTime ActionedOn { get; set; }
        public bool IsFavorite { get; set; }
    }
}
