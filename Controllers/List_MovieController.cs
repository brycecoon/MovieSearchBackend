using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;

namespace MovieSearchBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ListMovieController : Controller
{
    private readonly IList_MovieService _ListMovieService;
    public ListMovieController(IList_MovieService service)
    {
        _ListMovieService = service;
    }

    [HttpGet("getbyListId")]
    public async Task<List<ListMovie>> GetListMovieListAsync(int listId)
    {
        return await _ListMovieService.GetListMoviesByListIdAsync(listId);
    }

    [HttpPost]
    public async Task AddListMovieListAsync([FromBody] ListMovieDTO listMovie)
    {
        ListMovie newListMovie = new()
        {
            ListId = listMovie.listId,
            MovieId = listMovie.movieId
        };
        await _ListMovieService.AddToListAsync(newListMovie);
    }

    [HttpDelete("delete")]
    public async Task DeleteListMovieAsync(int listId, int movieId)
    {
        await _ListMovieService.DeleteFromListAsync(listId, movieId);
    }
}
