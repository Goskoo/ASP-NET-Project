using ASP_NET_Project.Data;
using ASP_NET_Project.Services;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class MineralController : Controller
    {
        private readonly MineralApplicationDbContext _context;
        private readonly IMineralService _mineralService;

        public MineralController(
            MineralApplicationDbContext context,
            IMineralService mineralService)
        {
            _context = context;
            _mineralService = mineralService;
        }
        //premestvane v services 
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
        //premestvane v services 

        public async Task<IActionResult> Details(int id)
        {
            var mineral = await _context.Minerals
                .Include(m => m.Locations)
                .Include(m => m.Museums)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mineral == null)
            {
                return NotFound();
            }
            return View(mineral);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _mineralService.GetEmptyForm();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MineralFormViewModel model)
        {
            int id = await _mineralService.CreateAsync(model);
            return RedirectToAction(nameof(Details), new { id });
        }
    }




}