using MovieSearchBackend.Data.DTOs;

namespace MovieSearchBackend.Data.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetUserListAsync();
    public Task CreateUser(UserDTO user);
    public Task UpdateUser(User user); 
}
