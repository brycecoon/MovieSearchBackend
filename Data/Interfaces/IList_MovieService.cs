namespace MovieSearchBackend.Data.Interfaces;

public interface IList_MovieService
{
    public Task DeleteFromListAsync(int listId, int movieId);
    public Task AddToListAsync(ListMovie movie);
    public Task<List<ListMovie>> GetListMoviesByListIdAsync(int id);

}
