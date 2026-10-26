using ASP_NET_Project.Data.Models;

namespace ASP_NET_Project.Services
{
    public interface IMuseumService
    {
        Task<IEnumerable<Museum>> GetAllAsync();
        Task<Museum?> GetDetailsAsync(int id);
    }
}
