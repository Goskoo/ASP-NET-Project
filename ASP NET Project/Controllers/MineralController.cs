using ASP_NET_Project.Services;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            page = Math.Max(page, 1);
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
            var model = await _mineralService.GetEmptyFormAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MineralFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await _mineralService.LoadOptionsAsync(model);
                return View(model);
            }
            int id = await _mineralService.CreateAsync(model);
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _mineralService.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            await _mineralService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _mineralService.GetFormByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MineralFormViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                await _mineralService.LoadOptionsAsync(model);
                return View(model);
            }

            if (!await _mineralService.EditAsync(id, model))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}