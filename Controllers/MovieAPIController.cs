using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json.Serialization;
using MovieSearchBackend.Data.JSONResponses;
namespace MovieSearchBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieAPIController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private string apiBaseURL;
    private string imageBaseUrl;
    private string genreUrl;
    public MovieAPIController(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _config = config;
        _httpClient = httpClientFactory.CreateClient();
        _apiKey = _config["apikey"] ?? throw new InvalidOperationException("API key not set");
        apiBaseURL = "https://api.themoviedb.org/3";
        imageBaseUrl = "https://image.tmdb.org/t/p/w300";
        genreUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={_apiKey}&language=en-US&sort_by=primary_release_date.desc&primary_release_year=2020&with_genres=";
    }

    [HttpGet("getNowPlaying")]
    public async Task<MovieDetails[]> GetNowPlayingMovies()
    {
        var response = await _httpClient.GetAsync($"{apiBaseURL}/movie/now_playing?api_key={_apiKey}&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=1980&vote_count.gte=100&vote_average.gte=5.5&with_watch_monetization_types=flatrate");
        if (response.IsSuccessStatusCode)
        {
            using var contentStream =
                await response.Content.ReadAsStreamAsync();

            var nowPlayingResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return nowPlayingResponse?.Results.ToArray();
        }
        else { return null; }
    }

    [HttpGet("getTrendingMovies")]
    public async Task<MovieDetails[]> GetTrendingMovies()
    {
        var response = await _httpClient.GetAsync($"{apiBaseURL}/trending/all/day?api_key={_apiKey}&sort_by=popularity.desc&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&primary_release_date.gte=1980&vote_count.gte=100&vote_average.gte=5.5&with_watch_monetization_types=flatrate");
        if (response.IsSuccessStatusCode)
        {
            using var contentStream =
                await response.Content.ReadAsStreamAsync();

            var trendingMovesResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return trendingMovesResponse?.Results.ToArray();
        }
        else { return null; }
    }

    [HttpGet("getMoviesByPage")]
    public async Task<MovieDetails[]> GetMoviesbyPage(int pageNum)
    {
        var response = await _httpClient.GetAsync($"{apiBaseURL}/movie/now_playing?api_key={_apiKey}&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&page={pageNum}&primary_release_date.gte=1980&vote_count.gte=100&vote_average.gte=5.5&with_watch_monetization_types=flatrate");
        if (response.IsSuccessStatusCode)
        {
            using var contentStream =
                await response.Content.ReadAsStreamAsync();

            var moviesByPageResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return moviesByPageResponse?.Results.ToArray();
        }
        else { return null; }
    }

    [HttpGet("getPageOfMoviesByGenre")]
    public async Task<MovieDetails[]> GetPageOfMoviesByGenre(int genreId, int pageNum)
    {
        var response = await _httpClient.GetAsync($"{genreUrl}{genreId}&language=en-US&sort_by=vote_average.desc&include_adult=false&include_video=false&page={pageNum}&primary_release_date.gte=1980&vote_count.gte=5&vote_average.gte=3&with_watch_monetization_types=flatrate");
        if (response.IsSuccessStatusCode)
        {
            using var contentStream =
                await response.Content.ReadAsStreamAsync();

            var moviesByPageResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return moviesByPageResponse?.Results.ToArray();
        }
        else { return null; }
    }

    [HttpGet("generateGenres")]
    public async Task<ActionResult<List<Genre>>> GenerateGenres()
    {
        var response = await _httpClient.GetAsync($"{apiBaseURL}/genre/movie/list?api_key={_apiKey}");

        if (response.IsSuccessStatusCode)
        {
            using var contentStream = await response.Content.ReadAsStreamAsync();

            var genreResponse = await JsonSerializer.DeserializeAsync<GenreResponse>(contentStream);

            return genreResponse?.Genres ?? new List<Genre>();
        }
        else
        {
            return StatusCode((int)response.StatusCode, "Error fetching genres.");
        }
    }
}
