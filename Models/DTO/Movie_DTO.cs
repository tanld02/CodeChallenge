using System.Text.Json.Serialization;

namespace CodeChallenge.Models.DTO
{
    public class Movie_DTO
    {
        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("rating")]
        public short? Rating { get; set; }
    }
}
