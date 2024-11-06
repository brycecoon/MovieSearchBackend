using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;

namespace MovieSearchBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ListController : Controller
{
    private readonly IListService _ListService;
    public ListController(IListService service)
    {
        _ListService = service;
    }

    [HttpGet("getAll")]
    public async Task<List<List>> GetListListAsync()
    {
        return await _ListService.GetAllListsAsync();
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
    public async Task UpdateListAsync(List list)
    {
        await _ListService.UpdateListAsync(list);
    }

    [HttpDelete]
    public async Task DeleteListAsync(int id)
    {
        await _ListService.DeleteListAsync(id);
    }
}
