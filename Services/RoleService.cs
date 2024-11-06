using Microsoft.EntityFrameworkCore;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.Interfaces;

namespace MovieSearchBackend.Services;

public class RoleService : IRoleService
{
    readonly PostgresContext _context;
    public RoleService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetRoleListAsync()
    {
        return await _context.Roles.ToListAsync();
    }
}
