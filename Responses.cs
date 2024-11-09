using System.Text.Json.Serialization;

namespace MovieSearchBackend;

public class NowPlayingResponse
{
    [JsonPropertyName("results")]
    public List<MovieDetails> Results { get; set; }
}
