using ASP_NET_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class MuseumController : Controller
    {
        private readonly MineralApplicationDbContext _context;
        public MuseumController(
            MineralApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var museums = await _context.Museums
                .Include(m => m.Minerals)
                .AsNoTracking()
                .ToListAsync();

            return View(museums);
        }
        public async Task<IActionResult> Details(int id)
        {
            var museum = await _context.Museums
                .Include(m => m.Minerals)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (museum == null)
            {
                return NotFound();
            }

                return View(museum);
            
        }
    }
}
