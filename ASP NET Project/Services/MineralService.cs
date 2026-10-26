using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ASP_NET_Project.Services
{
    public class MineralService : IMineralService
    {
        private readonly MineralApplicationDbContext _context;

        public MineralService(MineralApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mineral>> GetPageAsync(int page, int pageSize)
        {

            return await _context.Minerals
               .AsNoTracking()
               .OrderBy(m => m.Name)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

        }

        public async Task<Mineral?> GetByIdAsync(int id)
        {
            return await _context.Minerals
                .Include(m => m.Locations)
                .Include(m => m.Museums)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

        }
        public async Task<MineralFormViewModel> GetEmptyFormAsync()
        {
            var model = new MineralFormViewModel();

            await LoadOptionsAsync(model);

            return model;
        }

        public async Task<int> CreateAsync(MineralFormViewModel model)
        {
            Mineral mineral = new Mineral
            {
                Name = model.Name,
                Category = model.Category,
                Colors = model.Colors,
                Luster = model.Luster,
                Transparency = model.Transparency,
                MohsScale = model.MohsScale,
                CrystalSystem = model.CrystalSystem,
                CrystalHabit = model.CrystalHabit,
                Cleavage = model.Cleavage,
                Fracture = model.Fracture,
                Streak = model.Streak,
                Description = model.Description,
                CollectingTips = model.CollectingTips,
                ProcessingTips = model.ProcessingTips
            };

            mineral.Locations = await _context.Locations
                .Where(l => model.SelectedLocationIds.Contains(l.Id))
                .ToListAsync(); 

            mineral.Museums = await _context.Museums
                .Where(m => model.SelectedMuseumIds.Contains(m.Id))
                .ToListAsync();

            _context.Minerals.Add(mineral);
            await _context.SaveChangesAsync();
            return mineral.Id;
        }
        public async Task<bool> EditAsync(int id, MineralFormViewModel model)
        {
            var mineral = await _context.Minerals
            .Include(m => m.Locations)
            .Include(m => m.Museums)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (mineral == null)
            {
                return false;
            }

             mineral.Name = model.Name;
             mineral.Category = model.Category;
             mineral.Colors = model.Colors;
             mineral.Luster = model.Luster;
             mineral.Transparency = model.Transparency;
             mineral.MohsScale = model.MohsScale;
             mineral.CrystalSystem = model.CrystalSystem;
             mineral.CrystalHabit = model.CrystalHabit;
             mineral.Cleavage = model.Cleavage;
             mineral.Fracture = model.Fracture;
             mineral.Streak = model.Streak;
             mineral.Description = model.Description;
             mineral.CollectingTips = model.CollectingTips;
             mineral.ProcessingTips = model.ProcessingTips;

            var locations = await _context.Locations
                .Where(l => model.SelectedLocationIds.Contains(l.Id))
                .ToListAsync();

            mineral.Locations.Clear();

            foreach (var location in locations)
            {
                mineral.Locations.Add(location);
            }

            var museums = await _context.Museums
                .Where(m => model.SelectedMuseumIds.Contains(m.Id))
                .ToListAsync();

            mineral.Museums.Clear();

            foreach (var museum in museums)
            {
                mineral.Museums.Add(museum);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int Id)
        {
            var mineral = await _context.Minerals
                .FindAsync(Id);
            if (mineral != null)
            {
                _context.Minerals.Remove(mineral);
                await _context.SaveChangesAsync();


            }
        }
        public async Task<MineralFormViewModel?> GetFormByIdAsync(int id)
        {
            var mineral = await _context.Minerals
                .Include(m => m.Locations)
                .Include(m => m.Museums)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mineral == null)
            {
                return null;
            }
            var model = new MineralFormViewModel
            {
                Id = mineral.Id,
                Name = mineral.Name,
                Category = mineral.Category,
                Colors = mineral.Colors,
                Luster = mineral.Luster,
                Transparency = mineral.Transparency,
                MohsScale = mineral.MohsScale,
                CrystalSystem = mineral.CrystalSystem,
                CrystalHabit = mineral.CrystalHabit,
                Cleavage = mineral.Cleavage,
                Fracture = mineral.Fracture,
                Streak = mineral.Streak,
                Description = mineral.Description,
                CollectingTips = mineral.CollectingTips,
                ProcessingTips = mineral.ProcessingTips,
                SelectedLocationIds = mineral.Locations.Select(l => l.Id).ToList(),
                SelectedMuseumIds = mineral.Museums.Select(m => m.Id).ToList()

            };
            await LoadOptionsAsync(model);
            return model;
        }

        public async Task LoadOptionsAsync(MineralFormViewModel model)
        {
            model.Locations = await _context.Locations
                .AsNoTracking()
                .OrderBy(l => l.Country)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.Country} - {l.RegionName}"
                })
                .ToListAsync();

            model.Museums = await _context.Museums
                .AsNoTracking()
                .OrderBy(m=>m.Name)
                .Select(m=> new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                })
                .ToListAsync();
        }
    }
}
