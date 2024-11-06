namespace MovieSearchBackend.Data.Interfaces;

public interface IRoleService
{
    public Task<List<Role>> GetRoleListAsync();
}
