using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test_.Net.Models;
using Test_.Net.Services;

namespace Test_.Net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IComicBookService _comicBookService;

    public HomeController(ILogger<HomeController> logger, IComicBookService comicBookService)
    {
        _logger = logger;
        _comicBookService = comicBookService;
    }

    public IActionResult Index(ComicBook updateData)
    {
        _comicBookService.FindAll();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}