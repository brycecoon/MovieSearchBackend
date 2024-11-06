using Microsoft.EntityFrameworkCore;
using MovieSearchBackend.Data;
using MovieSearchBackend.Data.Interfaces;

namespace MovieSearchBackend.Services;

public class ListService : IListService
{
    readonly PostgresContext _context;
    public ListService(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddListAsync(List list)
    {
        _context.Lists.Add(list);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteListAsync(int id)
    {
        List listToDelete = _context.Lists.Where(l => l.Id == id).FirstOrDefault(); ;
        if (listToDelete != null)
        {
            _context.Lists.Remove(listToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<List>> GetAllListsAsync()
    {
        return await _context.Lists.ToListAsync();
    }

    public async Task UpdateListAsync(List list)
    {
        _context.Lists.Update(list);
        await _context.SaveChangesAsync();
    }
}
