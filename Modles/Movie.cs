namespace MovieManagement.Modles
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Synopsis { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
