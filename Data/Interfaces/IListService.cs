namespace MovieSearchBackend.Data.Interfaces;

public interface IListService
{
    public Task<List<List>> GetAllListsAsync();
    public Task AddListAsync(List list);
    public Task UpdateListAsync(List list);
    public Task DeleteListAsync(int id);
}
