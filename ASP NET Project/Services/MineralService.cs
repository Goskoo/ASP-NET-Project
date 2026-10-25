using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Enum;
using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;
using Azure.Core.Pipeline;
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
        public async Task EditAsync(int id, MineralFormViewModel model)
        {
            var mineral = await _context.Minerals.FindAsync(id);
            if (mineral != null)
            {
                mineral.Name = model.Name;
                mineral.Category = model.Category;
                mineral.Colors = model.Colors;
                mineral.Luster = model.Luster;
                mineral.Transparency = model.Transparency;
                mineral.MohsScale = model.MohsScale;
                mineral.CrystalSystem = model.CrystalSystem;
                mineral.Cleavage = model.Cleavage;
                mineral.Fracture = model.Fracture;
                mineral.Streak = model.Streak;
                mineral.Description = model.Description;
                mineral.CollectingTips = model.CollectingTips;
                mineral.ProcessingTips = model.ProcessingTips;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Mineral with Name {model.Name} and Id {id} not found.");
            }
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
        public async Task<MineralFormViewModel?> GetFormByIdAsync(int id)
        {
            var mineral = await _context.Minerals.FindAsync(id);
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
                Cleavage = mineral.Cleavage,
                Fracture = mineral.Fracture,
                Streak = mineral.Streak,
                Description = mineral.Description,
                CollectingTips = mineral.CollectingTips,
                ProcessingTips = mineral.ProcessingTips
            };
            return model;
        }
    }
}
