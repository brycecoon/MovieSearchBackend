using System.Text.Json.Serialization;

namespace MovieSearchBackend.Data.JSONResponses;

public class NowPlayingResponse
{
    [JsonPropertyName("results")]
    public List<MovieDetails>? Results { get; set; }
}

public class GenreResponse
{
    [JsonPropertyName("genres")]
    public List<Genre>? Genres { get; set; }
}

public class PersonResponse
{
    [JsonPropertyName("results")]
    public List<ActorDetails>? Actors { get; set; }
}


