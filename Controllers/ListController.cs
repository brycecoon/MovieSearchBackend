using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;
using MovieSearchBackend.Services;

namespace MovieSearchBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ListController : Controller
{
    private readonly IListService _ListService;
    private readonly IList_MovieService _ListMovieService;
    public ListController(IListService service, IList_MovieService listMovieService)
    {
        _ListService = service;
        _ListMovieService = listMovieService;   
    }

    [HttpGet("getAll/{userId}")]
    public async Task<List<List>> GetListListAsync(int userId)
    {
        return await _ListService.GetAllListsAsync(userId);
    }

    [HttpPost]
    public async Task AddListAsync([FromBody] ListDTO list)
    {
        List newList = new()
        {
            Name = list.name,
            UserId = list.userId
        };
        await _ListService.AddListAsync(newList);
    }

    [HttpPut]
    public async Task UpdateListAsync(EditListDTO list)
    {
        await _ListService.UpdateListAsync(list);
    }

    [HttpDelete("{id}")]
    public async Task DeleteListAsync(int id)
    {
        var list =  await _ListMovieService.GetListMoviesByListIdAsync(id);
        foreach (var listItem in list)
        {
            await _ListMovieService.DeleteFromListAsync(listItem.ListId, listItem.MovieId);
        }

        await _ListService.DeleteListAsync(id);
    }
}
