using ASP_NET_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Project.Controllers
{
    public class MuseumController : Controller
    {
        private readonly IMuseumService _museumService;
        public MuseumController(IMuseumService museumService)
        {
            _museumService = museumService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _museumService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _museumService.GetDetailsAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
