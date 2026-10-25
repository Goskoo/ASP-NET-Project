using ASP_NET_Project.Data;
using ASP_NET_Project.Services;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class MineralController : Controller
    {
        private readonly IMineralService _mineralService;

        public MineralController(IMineralService mineralService)
        {
            _mineralService = mineralService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 50;

            var model = await _mineralService.GetPageAsync(page, pageSize);
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            
            var model = await _mineralService.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
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