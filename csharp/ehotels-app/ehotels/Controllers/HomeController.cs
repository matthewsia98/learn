using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ehotels_data.DataAccess;
using ehotels.Models;

namespace ehotels.Controllers;

public class HomeController : Controller
{
    private readonly EhotelsDbContext context;

    public HomeController(EhotelsDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var hotelChains = this.context.HotelChains;
        var hotels = this.context.Hotels;
        return View(hotelChains);
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

