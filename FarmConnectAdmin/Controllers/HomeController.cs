using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FarmConnectAdmin.Models;

namespace FarmConnectAdmin.Controllers;

[AdminAuthorize]
public class HomeController : Controller
{
    private readonly FarmConnectAdmin.Data.ApplicationDbContext _context;

    public HomeController(FarmConnectAdmin.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new DashboardViewModel
        {
            UserCount = _context.Users.Count(),
            ProductCount = _context.Products.Count()
        };
        return View(model);
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
