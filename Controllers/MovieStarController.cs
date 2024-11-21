using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.JSONResponses;
using System.Text.Json;

namespace MovieSearchBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieStarController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private string apiBaseURL;
    private string imageBaseUrl;
    private string genreUrl;
    public MovieStarController(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _config = config;
        _httpClient = httpClientFactory.CreateClient();
        _apiKey = _config["apikey"] ?? throw new InvalidOperationException("API key not set");
        apiBaseURL = "https://api.themoviedb.org/3";
        imageBaseUrl = "https://image.tmdb.org/t/p/w300";
        genreUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={_apiKey}&language=en-US&sort_by=primary_release_date.desc&primary_release_year=2020&with_genres=";
    }

    [HttpGet("getPopular")]
    public async Task<ActorDetails[]> GetPopularActors(int pageNum)
    {
        var response = await _httpClient.GetAsync($"{apiBaseURL}/person/popular?api_key={_apiKey}&language=en-US&page={pageNum}");
        if (response.IsSuccessStatusCode)
        {
            using var contentStream =
                await response.Content.ReadAsStreamAsync();

            var actorResponse = await JsonSerializer.DeserializeAsync
                <PersonResponse>(contentStream);

            return actorResponse?.Actors.ToArray();
        }
        else { return null; }
    }
}
