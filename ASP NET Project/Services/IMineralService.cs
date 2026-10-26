using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;

namespace ASP_NET_Project.Services
{
    public interface IMineralService
    {
        Task<IEnumerable<Mineral>> GetPageAsync(int page, int pageSize);
        Task<Mineral?> GetByIdAsync(int id);
        Task<int> CreateAsync(MineralFormViewModel model);
        Task<MineralFormViewModel> GetEmptyFormAsync();
        Task DeleteAsync(int Id);
        Task<bool> EditAsync(int id, MineralFormViewModel model);
        Task<MineralFormViewModel?> GetFormByIdAsync(int id);
        Task LoadOptionsAsync(MineralFormViewModel model);
    }
}
