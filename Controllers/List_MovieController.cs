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

    [HttpGet("getAll")]
    public async Task<List<ListMovie>> GetListMovieListAsync()
    {
        return await _ListMovieService.GetList_MovieListAsync();
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

    [HttpDelete("{id}")]
    public async Task DeleteListMovieAsync(int id)
    {
        await _ListMovieService.DeleteFromListAsync(id);
    }
}
