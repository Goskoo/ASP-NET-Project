using ASP_NET_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class MineralController : Controller
    {
        private readonly MineralApplicationDbContext _context;

        public MineralController(
            MineralApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 50;

            var minerals = await _context.Minerals
                .AsNoTracking()
                .OrderBy(m => m.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(minerals);
        }


    }




}