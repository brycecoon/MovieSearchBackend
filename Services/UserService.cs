using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.DTOs;
using MovieSearchBackend.Data.Interfaces;

namespace MovieSearchBackend.Services;

public class UserService : IUserService
{
    readonly PostgresContext _context;
    public UserService(PostgresContext context)
    {
        _context = context;
    }

    public async Task CreateUser(UserDTO user)
    {
        User newUser = new()
        {
            Name = user.name,
            Email = user.email,
            Biography = user.biography,
            RoleId = user.roleId,
        };
        Console.WriteLine(user);
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetUserListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
