using ASP_NET_Project.ViewModels;

namespace ASP_NET_Project.Services
{
    public interface IMineralService
    {
        Task<int> CreateAsync(MineralFormViewModel model);
        Task<MineralFormViewModel> GetEmptyForm();
    }
}
