using ASP_NET_Project.Data.Models;

namespace ASP_NET_Project.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllAsync();

        Task<Location?> GetDetailsAsync(int id);
    }
}
