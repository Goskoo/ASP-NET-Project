using ASP_NET_Project.Data.Models;
using ASP_NET_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Project.Services
{
    public interface IMineralService
    {
        Task<IEnumerable<Mineral>> GetPageAsync(int page, int pageSize);
        Task<Mineral?> GetByIdAsync(int id);
        Task<int> CreateAsync(MineralFormViewModel model);
        Task<MineralFormViewModel> GetEmptyForm();
        Task DeleteAsync(int Id);
    }
}
