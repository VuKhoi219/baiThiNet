using Microsoft.AspNetCore.Mvc;
using Test_.Net.Data;
using Test_.Net.Models;

namespace Test_.Net.Controllers;

public class CustomersController : Controller
{
    private MyDbContext _context;

    public CustomersController(MyDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            customer.RegisterDate = DateTime.Now;
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(customer);
    }
}