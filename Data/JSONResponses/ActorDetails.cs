using System.Text.Json.Serialization;

namespace MovieSearchBackend.Data.JSONResponses;

public class KnownForMovie
{
    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }

    [JsonPropertyName("overview")]
    public string? Overview { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("media_type")]
    public string? MediaType { get; set; }

    [JsonPropertyName("adult")]
    public bool? Adult { get; set; }

    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("genre_ids")]
    public List<int>? GenreIds { get; set; }

    [JsonPropertyName("popularity")]
    public double? Popularity { get; set; }

    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }

    [JsonPropertyName("video")]
    public bool? Video { get; set; }

    [JsonPropertyName("vote_average")]
    public double? VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int? VoteCount { get; set; }
}

public class ActorDetails
{
    [JsonPropertyName("adult")]
    public bool? Adult { get; set; }

    [JsonPropertyName("gender")]
    public int Gender { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("known_for_department")]
    public string? KnownForDepartment { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("original_name")]
    public string? OriginalName { get; set; }

    [JsonPropertyName("popularity")]
    public double? Popularity { get; set; }

    [JsonPropertyName("profile_path")]
    public string? ProfilePath { get; set; }

    [JsonPropertyName("known_for")]
    public List<KnownForMovie>? KnownFor { get; set; }
}
