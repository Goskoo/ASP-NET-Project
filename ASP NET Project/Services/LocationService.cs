using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Services
{
    public class LocationService : ILocationService
    {
        private readonly MineralApplicationDbContext _context;

        public LocationService(MineralApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _context.Locations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Location?> GetDetailsAsync(int id)
        {
            return await _context.Locations
                .Include(l => l.Minerals)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);


        }
    }
}
