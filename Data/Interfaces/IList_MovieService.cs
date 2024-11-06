namespace MovieSearchBackend.Data.Interfaces;

public interface IList_MovieService
{
    public Task<List<ListMovie>> GetList_MovieListAsync();
    public Task DeleteFromListAsync(int id);
    public Task AddToListAsync(ListMovie movie);
}
