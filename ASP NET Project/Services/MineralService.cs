using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Enum;
using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<MineralFormViewModel> GetEmptyForm()
        {
            var model = new MineralFormViewModel();
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
                Cleavage = model.Cleavage,
                Fracture = model.Fracture,
                Streak = model.Streak,
                Description = model.Description,
                CollectingTips = model.CollectingTips,
                ProcessingTips = model.ProcessingTips
            };

            _context.Minerals.Add(mineral);
            await _context.SaveChangesAsync();
            return mineral.Id;
        }
    }
}
