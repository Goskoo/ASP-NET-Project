using ASP_NET_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Project.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(
            ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _locationService.GetAllAsync();
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _locationService.GetDetailsAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
