using Microsoft.AspNetCore.Mvc;
using Test_.Net.Data;
using Test_.Net.Models;

namespace Test_.Net.Controllers;

public class RentalsController : Controller
{
    private MyDbContext _context;

    public RentalsController(MyDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Rent() => View();

    [HttpPost]
    public async Task<IActionResult> Rent(Rental rental, List<RentalDetail> rentalDetails)
    {
        if (ModelState.IsValid)
        {
            _context.Add(rental);
            await _context.SaveChangesAsync();

            foreach (var detail in rentalDetails)
            {
                detail.RentalId = rental.RentalId;
                _context.Add(detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(rental);
    }
}