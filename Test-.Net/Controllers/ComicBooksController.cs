using Microsoft.AspNetCore.Mvc;
using Test_.Net.Data;
using Test_.Net.Models;
using Test_.Net.Services;

namespace Test_.Net.Controllers;

public class ComicBooksController : Controller
{
    private IComicBookService _comicBookService;

    public ComicBooksController(IComicBookService comicBookService)
    {
        _comicBookService = comicBookService;
    }

    public IActionResult Create()
    {
        return View(new ComicBook());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessCreate(
        [Bind("ComicBookId, Title, Author, PricePerDay")] ComicBook comicBook)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", comicBook);
        }
        await _comicBookService.Save(comicBook);
        return RedirectToAction("Index");
    }

    [Route("ComicBook/Detail/{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        var existingObject = await _comicBookService.FindById(id);
        if (existingObject == null)
        {
            return NotFound();
        }

        return View("Detail", existingObject);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int Id)
    {
        var existingObject = await _comicBookService.FindById(Id);
        if (existingObject == null)
        {
            return NotFound();
        }

        return View("Edit", existingObject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessEdit(
        [Bind("ComicBookId, Title, Author, PricePerDay")] ComicBook obj)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit", obj);
        }
        await _comicBookService.Update(obj);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _comicBookService.Delete(id);
        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}