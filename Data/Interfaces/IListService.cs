using MovieSearchBackend.Data.DTOs;

namespace MovieSearchBackend.Data.Interfaces;

public interface IListService
{
    public Task<List<List>> GetAllListsAsync();
    public Task AddListAsync(List list);
    public Task UpdateListAsync(EditListDTO list);
    public Task DeleteListAsync(int id);
}
