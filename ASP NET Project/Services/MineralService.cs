using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Enum;
using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;

namespace ASP_NET_Project.Services
{
    public class MineralService : IMineralService
    {
        private readonly MineralApplicationDbContext _context;

        public MineralService(MineralApplicationDbContext context)
        {
            _context = context;
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
