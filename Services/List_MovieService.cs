using Microsoft.EntityFrameworkCore;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.Interfaces;

namespace MovieSearchBackend.Services;

public class List_MovieService : IList_MovieService
{
    readonly PostgresContext _context;
    public List_MovieService(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddToListAsync(ListMovie movie)
    {
        _context.ListMovies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFromListAsync(int listId, int movieId)
    {
        ListMovie listMovieToRemove = await _context.ListMovies.Where(l => l.ListId == listId && l.MovieId == movieId).FirstOrDefaultAsync();
        if (listMovieToRemove != null)
        {
            _context.ListMovies.Remove(listMovieToRemove);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ListMovie>> GetListMoviesByListIdAsync(int id)
    {
        return await _context.ListMovies
            .Where(lm => lm.ListId == id)
            .ToListAsync();
    }
}
