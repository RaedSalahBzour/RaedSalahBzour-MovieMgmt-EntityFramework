using System.Text.Json.Serialization;

namespace MovieManagement.Modles
{
    public class Genre
    {
        public int GenreId { get; set; }
        public String? Name { get; set; }=string.Empty;
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
