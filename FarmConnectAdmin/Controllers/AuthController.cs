using Microsoft.AspNetCore.Mvc;
using FarmConnectAdmin.Data;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var admin = _context.Admins.FirstOrDefault(a =>
            a.Username == model.Username &&
            a.Password == model.Password);

        if (admin == null)
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        // ✅ Set session
        HttpContext.Session.SetString("Admin", admin.Username);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
