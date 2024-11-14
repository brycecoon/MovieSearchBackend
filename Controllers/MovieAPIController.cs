using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
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

            var nowPlayingResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return nowPlayingResponse?.Results.ToArray();
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

            var nowPlayingResponse = await JsonSerializer.DeserializeAsync
                <NowPlayingResponse>(contentStream);

            return nowPlayingResponse?.Results.ToArray();
        }
        else { return null; }
    }
}
