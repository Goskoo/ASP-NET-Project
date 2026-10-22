using ASP_NET_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class LocationController : Controller
    {
        private readonly MineralApplicationDbContext _context;

        public LocationController(
            MineralApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> index()
        {
            var location = await _context.Locations
                .Include(l => l.Minerals)
                .ToListAsync();

            return View(location);
        }

        public async Task<IActionResult> Details(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Minerals)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }
    }
}
