using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data.Interfaces;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

    [HttpGet("testAuthorize")]
    public async Task<string> testAuthorize()
    {
        var email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        return email ?? "Email not found";
    }

    [HttpGet("getAll")]
    public async Task<List<User>> GetUserListAsync()
    {
        return await _UserService.GetUserListAsync();
    }

    [HttpGet("getByEmail")]
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _UserService.getUserByEmail(email);
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
