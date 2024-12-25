using Microsoft.EntityFrameworkCore;
using Test_.Net.Data;
using Test_.Net.Models;

namespace Test_.Net.Services;

public class ComicBookService : IComicBookService
{
    private MyDbContext _context;

    public ComicBookService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ComicBook>> FindAll()
    {
        return await _context.ComicBooks.ToListAsync();
    }

    public async Task<ComicBook> FindById(int Id)
    {
        return await _context.ComicBooks.FirstOrDefaultAsync(c => c.ComicBookId == Id);
    }

    public async Task<ComicBook> Save(ComicBook comicBook)
    {
        _context.ComicBooks.Add(comicBook);
        await _context.SaveChangesAsync();
        return comicBook;
    }

    public async Task<ComicBook> Update(ComicBook comicBook)
    {
        _context.ComicBooks.Update(comicBook);
        await _context.SaveChangesAsync();
        return comicBook;
    }

    public async Task<bool> Delete(int Id)
    {
        var customer = await _context.ComicBooks.FindAsync();
        if (customer != null)
        {
            _context.ComicBooks.Remove(customer);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }
}