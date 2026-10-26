using ASP_NET_Project.Data;
using ASP_NET_Project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Services
{
    public class MuseumService : IMuseumService
    {
        private readonly MineralApplicationDbContext _context;
        public MuseumService(MineralApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Museum>> GetAllAsync()
        {
            return await _context.Museums
                .AsNoTracking()
                .ToListAsync();


        }
        public async Task<Museum?> GetDetailsAsync(int id)
        {
            return await _context.Museums
                .Include(m => m.Minerals)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

        }
    }
}
