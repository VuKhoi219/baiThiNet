using Test_.Net.Models;

namespace Test_.Net.Services;

public interface IComicBookService
{
    Task<List<ComicBook>> FindAll();
    Task<ComicBook> FindById(int Id);
    Task<ComicBook> Save(ComicBook comicBook);
    Task<ComicBook> Update(ComicBook comicBook);
    Task<bool> Delete(int Id);
}