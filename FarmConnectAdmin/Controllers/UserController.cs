using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmConnectAdmin.Data;
using FarmConnectAdmin.Models;
using FarmConnectAdmin.Utilities;

namespace FarmConnectAdmin.Controllers
{
    [AdminAuthorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ: List all users with Pagination
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var users = _context.Users.AsNoTracking().OrderByDescending(u => u.CreatedAt);
            int pageSize = 10;
            return View(await PaginatedList<User>.CreateAsync(users, pageNumber ?? 1, pageSize));
        }

        // READ: User details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null) return NotFound();

            return View(user);
        }

        // CREATE: Show form
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: Save user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (await EmailExists(user.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(user);
            }

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // UPDATE: Show edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // UPDATE: Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(user);

            if (await EmailExists(user.Email, user.Id))
            {
                ModelState.AddModelError("Email", "This email is already taken.");
                return View(user);
            }

            try 
            {
                user.UpdatedAt = DateTime.Now;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id)) return NotFound();
                else throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // DELETE: Confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null) return NotFound();

            return View(user);
        }

        // DELETE: Confirm delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmailExists(string email, int? excludeId = null)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && (!excludeId.HasValue || u.Id != excludeId));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
