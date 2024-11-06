using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;

namespace MovieSearchBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;
    public UserController(IUserService service)
    {
        _UserService = service;
    }

    [HttpGet("getAll")]
    public async Task<List<User>> GetUserListAsync()
    {
        return await _UserService.GetUserListAsync();
    }

    [HttpPut("edit")]
    public async Task UpdateUserListAsync([FromBody] User User)
    {
        await _UserService.UpdateUser(User);
    }

    [HttpPost("add")]
    public async Task AddUserAsync([FromBody] UserDTO user)
    {
        await _UserService.CreateUser(user);
    }
}
