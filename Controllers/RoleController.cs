using Microsoft.AspNetCore.Mvc;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.Interfaces;

namespace MovieSearchBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _RoleService;
    public RoleController(IRoleService service)
    {
        _RoleService = service;
    }

    [HttpGet("getAll")]
    public async Task<List<Role>> GetRoleListAsync()
    {
        return await _RoleService.GetRoleListAsync();
    }
}
